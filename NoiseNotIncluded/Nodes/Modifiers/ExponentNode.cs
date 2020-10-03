using LibNoise;
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
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ExponentNode>));
    }

    protected override IModule GetNewOutput()
    {
      return null;
    }
  }
}
