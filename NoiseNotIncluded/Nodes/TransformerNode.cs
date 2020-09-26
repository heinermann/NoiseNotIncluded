
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes
{
  public class TransformerNode : NodeViewModel
  {
    public ValueNodeInputViewModel<float> SelectNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Select"
    };
    public ValueNodeInputViewModel<float> XNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "X"
    };
    public ValueNodeInputViewModel<float> YNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Y"
    };
    public ValueNodeInputViewModel<float> ZNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Z"
    };

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public TransformerNode()
    {
      Inputs.Add(SelectNode);
      Inputs.Add(XNode);
      Inputs.Add(YNode);
      Inputs.Add(ZNode);

      Outputs.Add(NodeOutput);
    }
  }
}
