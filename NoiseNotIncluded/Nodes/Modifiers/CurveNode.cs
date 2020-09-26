using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class CurveNode : ModifierNode
  {
    public CurveNode() : base()
    {
      Name = "Curve";
    }

    static CurveNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<CurveNode>));
    }
  }
}
