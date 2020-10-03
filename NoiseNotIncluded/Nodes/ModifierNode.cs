using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using NoiseNotIncluded.Util;
using System.Reactive.Linq;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public abstract class ModifierNode : NodeWithPreview
  {
    // Lower, Upper (Clamp)
    // Exponent (Exponent)
    // Invert (unused)
    // Scale, Bias (ScaleBias)
    // Scale2D (with x, y) (Scale2D)

    public ValueNodeInputViewModel<IModule> NodeInput { get; } = NodeHelpers.CreateNodeInput("Input");

    public ModifierNode() : base()
    {
      Inputs.Add(NodeInput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.DarkGreen
      };
    }
  }
}
