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

      // Load the file
      string rawYaml = File.ReadAllText(ofd.FileName);
      IDeserializer yaml = new DeserializerBuilder().Build();
      NoiseFile noise = yaml.Deserialize<NoiseFile>(rawYaml);

      // Convert nodes in file to editor nodes
      Dictionary<string, NodeViewModel> primitives = noise.primitives.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> combiners = noise.combiners.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> filters = noise.filters.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> modifiers = noise.modifiers.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      //Dictionary<string, NodeViewModel> selectors = noise.selectors.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> transformers = noise.transformers.ToDictionary(x => x.Key, x => x.Value.CreateModel());

      //Dictionary<string, NodeViewModel> controlPoints = noise.controlpoints.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      //Dictionary<string, NodeViewModel> floats = noise.floats.ToDictionary(x => x.Key, x => x.Value.CreateModel());

      Dictionary<Link.Type, Dictionary<string, NodeViewModel>> typeMap = new Dictionary<Link.Type, Dictionary<string, NodeViewModel>>{
        { Link.Type.Primitive, primitives },
        { Link.Type.Combiner, combiners },
        { Link.Type.Filter, filters },
        { Link.Type.Modifier, modifiers },
        //{ Link.Type.Selector, selectors },
        { Link.Type.Transformer, transformers },
        //{ Link.Type.ControlPoints, controlPoints },
        //{ Link.Type.FloatPoints, floats }
      };

      // Add the nodes to the graph
      ViewModel.NetworkViewModel.Nodes.Clear();

      ViewModel.NetworkViewModel.Nodes.AddRange(primitives.Values);
      ViewModel.NetworkViewModel.Nodes.AddRange(combiners.Values);
      ViewModel.NetworkViewModel.Nodes.AddRange(filters.Values);
      ViewModel.NetworkViewModel.Nodes.AddRange(modifiers.Values);
      //ViewModel.NetworkViewModel.Nodes.AddRange(selectors.Values);
      ViewModel.NetworkViewModel.Nodes.AddRange(transformers.Values);
      //ViewModel.NetworkViewModel.Nodes.AddRange(controlPoints.Values);
      //ViewModel.NetworkViewModel.Nodes.AddRange(floats.Values);

      TerminatorNode terminatorNode = new TerminatorNode();
      ViewModel.NetworkViewModel.Nodes.Add(terminatorNode);
      
      // Connect the graph using links
      foreach (NodeLink link in noise.links)
      {
        NodeOutputViewModel source0 = link.source0 != null ? typeMap[link.source0.type][link.source0.name].Outputs.Items.First() : null;
        NodeOutputViewModel source1 = link.source1 != null ? typeMap[link.source1.type][link.source1.name].Outputs.Items.First() : null;
        NodeOutputViewModel source2 = link.source2 != null ? typeMap[link.source2.type][link.source2.name].Outputs.Items.First() : null;
        NodeOutputViewModel source3 = link.source3 != null ? typeMap[link.source3.type][link.source3.name].Outputs.Items.First() : null;
        
        switch (link.target.type)
        {
          
          case Link.Type.Filter:
            var filter = filters[link.target.name] as FilterNode;
            ViewModel.AddConnection(filter.NodeInput, source0);
            break;
            /*
          case Link.Type.Transformer:
            var transformer = transformers[link.target.name] as TransformerNode;
            ViewModel.AddConnection(transformer.SelectNode, source0);
            ViewModel.AddConnection(transformer.XNode, source1);
            ViewModel.AddConnection(transformer.YNode, source2);
            ViewModel.AddConnection(transformer.ZNode, source3);
            break;*/
          case Link.Type.Selector:
            // TODO
            break;/*
          case Link.Type.Modifier:
            var modifier = modifiers[link.target.name] as ModifierNode;
            ViewModel.AddConnection(modifier.NodeInput, source0);
            break;*/
          case Link.Type.Combiner:
            var combiner = combiners[link.target.name] as CombinerNode;
            ViewModel.AddConnection(combiner.LeftInput, source0);
            ViewModel.AddConnection(combiner.RightInput, source1);
            break;
          case Link.Type.Terminator:
            ViewModel.AddConnection(terminatorNode.NodeInput, source0);
            break;
        }
      }

    }
  }
}
