using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class TerraceNode : ModifierNode
  {
    public TerraceNode() : base()
    {
      Name = "Terrace";
    }

    static TerraceNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<TerraceNode>));
    }
  }
}
