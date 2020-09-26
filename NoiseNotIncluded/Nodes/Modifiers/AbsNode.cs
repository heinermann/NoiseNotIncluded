using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class AbsNode : ModifierNode
  {
    public AbsNode() : base()
    {
      Name = "Abs";
    }

    static AbsNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AbsNode>));
    }
  }
}
