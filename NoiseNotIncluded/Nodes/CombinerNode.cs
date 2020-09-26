using NodeNetwork.ViewModels;
using NodeNetwork.Toolkit.ValueNode;
using DynamicData;
using ReactiveUI;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class CombinerNode : NodeViewModel
  {
    public ValueNodeInputViewModel<float> LeftInput { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Left"
    };

    public ValueNodeInputViewModel<float> RightInput { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Right"
    };

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public CombinerNode()
    {
      Inputs.Add(LeftInput);
      Inputs.Add(RightInput);

      Outputs.Add(NodeOutput);
    }
  }
}
