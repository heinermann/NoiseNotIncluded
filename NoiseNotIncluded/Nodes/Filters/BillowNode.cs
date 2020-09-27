using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class BillowNode : FilterNode
  {
    public BillowNode() : base()
    {
      Name = "Billow";
    }

    static BillowNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<BillowNode>));
    }
  }
}
