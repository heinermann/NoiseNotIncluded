using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Selectors
{
  public class SelectNode : SelectorNode
  {
    public SelectNode() : base()
    {
      Name = "Select";
    }

    static SelectNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SelectNode>));
    }
  }
}
