
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using System.Reactive.Linq;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public class SelectorNode : NodeViewModel
  {
    // Lower
    // Upper
    // Edge (as EdgeFalloff in LibNoise)
    // ^ Only for SelectNode

    public ValueNodeInputViewModel<float> SelectNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Select"
    };
    public ValueNodeInputViewModel<float> RightNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Right"
    };
    public ValueNodeInputViewModel<float> LeftNode { get; } = new ValueNodeInputViewModel<float>()
    {
      Name = "Left"
    };

    public ValueNodeOutputViewModel<float> NodeOutput { get; } = new ValueNodeOutputViewModel<float>()
    {
      Name = "Output",
      Value = Observable.Return(1.0f)
    };

    public SelectorNode()
    {
      Inputs.Add(SelectNode);
      Inputs.Add(LeftNode);
      Inputs.Add(RightNode);

      Outputs.Add(NodeOutput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.DarkViolet
      };
    }
  }
}
