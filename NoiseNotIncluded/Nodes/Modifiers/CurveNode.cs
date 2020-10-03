using LibNoise;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  // TODO controlPoints
  public class CurveNode : ModifierNode
  {
    public CurveNode() : base()
    {
      Name = "Curve";
    }

    static CurveNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<CurveNode>));
    }

    protected override IModule GetNewOutput()
    {
      return null;
    }
  }
}
