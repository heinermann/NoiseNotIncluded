
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes
{
  public class ModifierNode : NodeViewModel
  {
    // Lower (Clamp)
    // Upper (Clamp)
    // Exponent (Exponent)
    // Invert (unused)
    // Scale (ScaleBias)
    // Bias (ScaleBias)
    // Scale2D (with x, y) (Scale2D)

    public ValueNodeInputViewModel<float> NodeInput { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Input"
    };

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public ModifierNode()
    {
      Inputs.Add(NodeInput);
      Outputs.Add(NodeOutput);
    }
  }
}
