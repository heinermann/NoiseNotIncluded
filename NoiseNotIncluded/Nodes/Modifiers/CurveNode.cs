using LibNoise;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  // TODO controlPoints
  public class CurveNode : ModifierNode
  {
    protected override Modifier.ModifyType ModifyType => Modifier.ModifyType.Curve;

    public CurveNode() : base()
    {
      Name = $"Curve_{Uuid()}";
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
