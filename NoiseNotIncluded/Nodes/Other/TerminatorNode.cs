using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes.Other
{
  public class TerminatorNode : NodeViewModel
  {
    public ValueNodeInputViewModel<float> NodeInput { get; } = new ValueNodeInputViewModel<float>()
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
      var result = new NodeView();
      result.Background = Brushes.Black;
      return result;
    }
  }
}
