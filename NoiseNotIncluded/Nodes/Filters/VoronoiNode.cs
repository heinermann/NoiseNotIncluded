using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class VoronoiNode : FilterNode
  {
    public VoronoiNode() : base()
    {
      Name = "Voronoi";
    }

    static VoronoiNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<VoronoiNode>));
    }
  }
}
