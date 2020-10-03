using LibNoise;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class InvertNode : ModifierNode
  {
    public InvertNode() : base()
    {
      Name = "Invert";
    }

    static InvertNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<InvertNode>));
    }

    protected override IModule GetNewOutput()
    {
      return null;
    }
  }
}
