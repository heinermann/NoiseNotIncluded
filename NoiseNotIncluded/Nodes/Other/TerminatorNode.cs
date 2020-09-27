using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes.Other
{
  public class TerminatorNode : NodeViewModel
  {
    public ValueNodeInputViewModel<IModule> NodeInput { get; } = new ValueNodeInputViewModel<IModule>()
    {
      Name = "Input"
    };

    public TerminatorNode()
    {
      Name = "TERMINATOR";

      Inputs.Add(NodeInput);
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
