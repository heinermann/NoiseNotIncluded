using Microsoft.Win32;
using NodeNetwork.Toolkit.Layout.ForceDirected;
using NoiseNotIncluded.Nodes.Other;
using NoiseNotIncluded.Properties;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace NoiseNotIncluded
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, IViewFor<MainViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(MainViewModel), typeof(MainWindow), new PropertyMetadata(null));

    public MainViewModel ViewModel
    {
      get => (MainViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (MainViewModel)value;
    }
    #endregion

    Dictionary<MenuItem, string> recentFilesPathMap = new Dictionary<MenuItem, string>();

    public MainWindow()
    {
      InitializeComponent();

      ViewModel = new MainViewModel();

      this.WhenActivated(d =>
      {
        this.OneWayBind(ViewModel, vm => vm.ListViewModel, v => v.nodeList.ViewModel).DisposeWith(d);
        this.OneWayBind(ViewModel, vm => vm.NetworkViewModel, v => v.networkView.ViewModel).DisposeWith(d);
      });

      ViewModel.New();
      noiseProperties.SelectedObject = ViewModel.FileData.settings;

      if (Settings.Default.RecentFiles == null) Settings.Default.RecentFiles = new StringCollection();
      ResetRecentFilesMenu();
    }

    private void Exit_Clicked(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void AutoLayout_Click(object sender, RoutedEventArgs e)
    {
      ForceDirectedLayouter layouter = new ForceDirectedLayouter();
      var config = new Configuration
      {
        Network = ViewModel.NetworkViewModel
      };
      layouter.Layout(config, 10000);
    }

    private bool AllowedToProceed()
    {
      return true;
    }

    private void New_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      if (!AllowedToProceed()) return;

      ViewModel.New();
      noiseProperties.SelectedObject = ViewModel.FileData.settings;
    }

    private void ResetRecentFilesMenu()
    {
      recentFilesPathMap.Clear();
      recentFilesList.Items.Clear();

      foreach (string filename in Settings.Default.RecentFiles)
      {
        MenuItem newMenu = new MenuItem() { Header = filename };
        newMenu.Click += new RoutedEventHandler(Open_RecentMenuItem);
        recentFilesPathMap.Add(newMenu, filename);
        recentFilesList.Items.Add(newMenu);
      }
    }

    private void UpdateRecentFilesList(string newFilename)
    {
      var newList = Settings.Default.RecentFiles.Cast<string>().ToList();
      newList.RemoveAll(filename => filename == newFilename);

      Settings.Default.RecentFiles.Clear();
      Settings.Default.RecentFiles.AddRange(newList.Prepend(newFilename).Take(15).ToArray());
      Settings.Default.Save();

      ResetRecentFilesMenu();
    }

    private void OpenFile(string filename)
    {
      ViewModel.LoadFile(filename);
      noiseProperties.SelectedObject = ViewModel.FileData.settings;

      UpdateRecentFilesList(filename);
    }

    private void Open_RecentMenuItem(object sender, RoutedEventArgs e)
    {
      MenuItem item = sender as MenuItem;
      if (item == null) return;

      if (!AllowedToProceed()) return;

      OpenFile(recentFilesPathMap[item]);
    }

    private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      if (!AllowedToProceed()) return;

      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "yaml files (*.yaml)|*.yaml|All files (*.*)|*.*";
      if (ofd.ShowDialog() != true) return;

      OpenFile(ofd.FileName);
    }

    private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      ViewModel.Save();
    }

    private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "yaml files (*.yaml)|*.yaml|All files (*.*)|*.*";
      if (sfd.ShowDialog() != true) return;

      ViewModel.SaveFile(sfd.FileName);
      UpdateRecentFilesList(sfd.FileName);
    }

    private void noiseProperties_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
      ViewModel.SyncZoom();
    }

    private void Undo_Executed(object sender, ExecutedRoutedEventArgs e)
    {
    }

    private void Redo_Executed(object sender, ExecutedRoutedEventArgs e)
    {
    }

    private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
    {
    }

    private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
    {
    }

    private void SelectAll_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      ViewModel.NetworkViewModel.Nodes.Items.ToList().ForEach(node => node.IsSelected = true);
    }

    private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      var selectedNodes = ViewModel.NetworkViewModel.SelectedNodes.Items
        .Where(node => !(node is TerminatorNode)).ToList();

      ViewModel.NetworkViewModel.Nodes.Edit(
        nodeList => selectedNodes.ForEach(selectedNode => nodeList.Remove(selectedNode))
      );
    }
  }
}
