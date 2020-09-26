using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ExponentNode : ModifierNode
  {
    public ExponentNode() : base()
    {
      Name = "Exponent";
    }

    static ExponentNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ExponentNode>));
    }
  }
}
