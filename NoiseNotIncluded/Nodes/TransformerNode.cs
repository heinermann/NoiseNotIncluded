
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using System.Reactive.Linq;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public class TransformerNode : NodeViewModel
  {
    // Power (TurbulenceNode)
    // Rotation (x,y) (RotatePointNode)

    public ValueNodeInputViewModel<float> SelectNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Select"
    };

    // X/Y/Z is only for TurbulenceNode and DisplaceNode
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
    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Orange
      };
    }
  }
}
