using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using NoiseNotIncluded.Util;
using NoiseNotIncluded.Yaml;
using NoiseNotIncluded.Yaml.Noise.Nodes;
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

    protected abstract Modifier.ModifyType ModifyType { get; }
    public override Link.Type NodeType => Link.Type.Modifier;

    public ValueNodeInputViewModel<IModule> NodeInput { get; } = NodeHelpers.CreateNodeInput("Input");

    public ModifierNode() : base()
    {
      Inputs.Add(NodeInput);
    }

    protected static NodeView GetNodeView()
    {
      return NodeHelpers.CreateNodeView(Brushes.DarkGreen);
    }

    public override NoiseBase GetYamlNode()
    {
      return new Modifier()
      {
        modifyType = this.ModifyType,
        name = this.Name,
        pos = this.Position
      };
    }
  }
}
