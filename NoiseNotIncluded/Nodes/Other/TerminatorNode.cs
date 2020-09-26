using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

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
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<TerminatorNode>));
    }
  }
}
