using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes.Other
{
  public class ControlPointNode : NodeViewModel
  {
    // Points (list of Control, each with [Input, Output] which are floats)

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public ControlPointNode()
    {
      Name = "Control Points";

      Outputs.Add(NodeOutput);
    }

    static ControlPointNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ControlPointNode>));
    }
  }
}
