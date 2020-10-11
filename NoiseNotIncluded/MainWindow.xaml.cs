using DynamicData;
using Microsoft.Win32;
using NodeNetwork.Toolkit.Layout.ForceDirected;
using NodeNetwork.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Combiners;
using NoiseNotIncluded.Nodes.Other;
using NoiseNotIncluded.Yaml;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Windows;
using YamlDotNet.Serialization;

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
        //this.OneWayBind(ViewModel, vm => vm.ValueLabel, v => v.valueLabel.Content).DisposeWith(d);
      });
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

    private void Open_Clicked(object sender, RoutedEventArgs e)
    {
      // Choose the file
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "yaml files (*.yaml)|*.yaml|All files (*.*)|*.*";
      if (ofd.ShowDialog() != true) return;

      ViewModel.LoadFile(ofd.FileName);
    }

    private void SaveAs_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "yaml files (*.yaml)|*.yaml|All files (*.*)|*.*";
      if (sfd.ShowDialog() != true) return;

      ViewModel.SaveFile(sfd.FileName);
    }
  }
}
