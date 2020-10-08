using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;
using System;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes.Other
{
  public class TerminatorNode : NodeViewModel
  {
    public ValueNodeInputViewModel<IModule> NodeInput { get; } = new ValueNodeInputViewModel<IModule>()
    {
      Name = "Input"
    };

    public NodeOutputViewModel NodeOutput { get; }

    OutputPreviewModel OutputPreview { get; } = new OutputPreviewModel();

    public TerminatorNode()
    {
      Name = "TERMINATOR";
      CanBeRemovedByUser = false;

      NodeOutput = new NodeOutputViewModel
      {
        Editor = OutputPreview,
        MaxConnections = 0
      };

      NodeInput.ValueChanged.Subscribe(module => OutputPreview.Value = module);

      Inputs.Add(NodeInput);

      NodeOutput.Port.IsVisible = false;
      Outputs.Add(NodeOutput);
    }

    static TerminatorNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<TerminatorNode>));
    }

    static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Black
      };
    }
  }
}
