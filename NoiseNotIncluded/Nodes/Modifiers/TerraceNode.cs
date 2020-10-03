using LibNoise;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  // TODO: ControlFloats
  public class TerraceNode : ModifierNode
  {
    public TerraceNode() : base()
    {
      Name = "Terrace";
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
