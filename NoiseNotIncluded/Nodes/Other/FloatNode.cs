using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes.Other
{
  public class FloatNode : NodeViewModel
  {
    // Points (list of floats)

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public FloatNode()
    {
      Name = "Floats";

      Outputs.Add(NodeOutput);
    }

    static FloatNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<FloatNode>));
    }
  }
}
