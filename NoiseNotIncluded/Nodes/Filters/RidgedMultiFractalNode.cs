using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class RidgedMultiFractalNode : FilterNode
  {
    public RidgedMultiFractalNode() : base()
    {
      Name = "RidgedMultiFractal";
    }

    static RidgedMultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<RidgedMultiFractalNode>));
    }
  }
}
