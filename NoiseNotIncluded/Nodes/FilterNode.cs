using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes
{
  public class FilterNode : NodeViewModel
  {
    // Frequency
    // Lacunarity
    // OctaveCount (as Octaves in ONI)
    // Offset
    // Gain
    // SpectralExponent (as Exponent in ONI)
    // 
    // Uses Primitive3D

    public ValueNodeInputViewModel<float> NodeInput { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Input"
    };

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public FilterNode()
    {
      Inputs.Add(NodeInput);
      Outputs.Add(NodeOutput);
    }
  }
}
