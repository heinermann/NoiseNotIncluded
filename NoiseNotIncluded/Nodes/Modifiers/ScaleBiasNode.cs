using LibNoise;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ScaleBiasNode : ModifierNode
  {
    public ScaleBiasNode() : base()
    {
      Name = "ScaleBias";
    }

    static ScaleBiasNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ScaleBiasNode>));
    }

    protected override IModule GetNewOutput()
    {
      return null;
    }
  }
}
