using Microsoft.Win32;
using NodeNetwork.Toolkit.Layout.ForceDirected;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;
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
      layouter.Layout(config, 50000);
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

    private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      if (!AllowedToProceed()) return;

      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "yaml files (*.yaml)|*.yaml|All files (*.*)|*.*";
      if (ofd.ShowDialog() != true) return;

      ViewModel.LoadFile(ofd.FileName);
      noiseProperties.SelectedObject = ViewModel.FileData.settings;
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
    }

    private void noiseProperties_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
      ViewModel.SyncZoom();
    }
  }
}
