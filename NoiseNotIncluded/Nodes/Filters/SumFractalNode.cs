using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class SumFractalNode : FilterNode
  {
    public SumFractalNode() : base()
    {
      Name = "SumFractal";
    }

    static SumFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SumFractalNode>));
    }
  }
}
