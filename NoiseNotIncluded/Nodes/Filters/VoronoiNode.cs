using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class VoronoiNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.Voronoi;

    // Frequency

    public VoronoiNode() : base()
    {
      Name = $"Voronoi_{Uuid()}";

      Inputs.Add(Frequency);
    }

    static VoronoiNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<VoronoiNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new Voronoi();
    }
  }
}
