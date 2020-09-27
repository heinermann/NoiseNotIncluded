using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Selectors
{
  public class BlendNode : SelectorNode
  {
    public BlendNode() : base()
    {
      Name = "Blend";
    }

    static BlendNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<BlendNode>));
    }
  }
}
