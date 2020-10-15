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
  public abstract class TransformerNode : NodeWithPreview
  {
    // Power (TurbulenceNode)
    // Rotation (x,y) (RotatePointNode)
    // xModule, yModule, ZModule

    public ValueNodeInputViewModel<IModule> SelectNode { get; } = NodeHelpers.CreateNodeInput("Select");

    // X/Y/Z is only for TurbulenceNode and DisplaceNode
    public ValueNodeInputViewModel<IModule> XNode { get; } = NodeHelpers.CreateNodeInput("X");
    public ValueNodeInputViewModel<IModule> YNode { get; } = NodeHelpers.CreateNodeInput("Y");
    public ValueNodeInputViewModel<IModule> ZNode { get; } = NodeHelpers.CreateNodeInput("Z");

    protected abstract Transformer.TransformerType TransformerType { get; }
    public override Link.Type NodeType => Link.Type.Transformer;

    public TransformerNode() : base()
    {
      Inputs.Add(SelectNode);
    }

    protected static NodeView GetNodeView()
    {
      return NodeHelpers.CreateNodeView(Brushes.Orange);
    }

    public override NoiseBase GetYamlNode()
    {
      return new Transformer()
      {
        transformerType = this.TransformerType,
        name = this.Name,
        pos = this.Position
      };
    }
  }
}
