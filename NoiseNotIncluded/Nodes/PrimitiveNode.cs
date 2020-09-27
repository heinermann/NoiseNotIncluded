
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using System.Reactive.Linq;
using System.Windows.Media;

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

    protected static NodeView GetNodeView()
    {
      var result = new NodeView();
      result.Background = Brushes.Red;
      return result;
    }
  }
}
