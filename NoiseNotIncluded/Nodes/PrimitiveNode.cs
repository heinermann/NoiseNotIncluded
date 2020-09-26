
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes
{
  public class PrimitiveNode : NodeViewModel
  {
    // Quality (LibNoise.NoiseQuality [Fast, Standard, Best])
    // Seed
    // Offset (Only Constant, Cylinders, and Spheres)
    // 

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public PrimitiveNode()
    {
      Outputs.Add(NodeOutput);
    }
  }
}
