using LibNoise;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  // TODO: ControlFloats
  public class TerraceNode : ModifierNode
  {
    protected override Modifier.ModifyType ModifyType => Modifier.ModifyType.Terrace;

    public TerraceNode() : base()
    {
      Name = $"Terrace_{Uuid()}";
    }

    static TerraceNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<TerraceNode>));
    }

    protected override IModule GetNewOutput()
    {
      return null;
    }
  }
}
