using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class HeterogeneousMultiFractalNode : FilterNode
  {
    public HeterogeneousMultiFractalNode() : base()
    {
      Name = "HeterogeneousMultiFractal";
    }

    static HeterogeneousMultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<HeterogeneousMultiFractalNode>));
    }
  }
}
