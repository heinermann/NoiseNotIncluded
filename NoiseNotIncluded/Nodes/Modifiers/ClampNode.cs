using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ClampNode : ModifierNode
  {
    public ClampNode() : base()
    {
      Name = "Clamp";
    }

    static ClampNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ClampNode>));
    }
  }
}
