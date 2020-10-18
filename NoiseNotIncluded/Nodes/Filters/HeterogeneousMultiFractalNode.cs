using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class HeterogeneousMultiFractalNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.HeterogeneousMultiFractal;

    // Lacunarity, Frequency, Octaves, Offset

    public HeterogeneousMultiFractalNode() : base()
    {
      Name = $"HeterogeneousMultiFractal_{Uuid()}";

      Inputs.Add(Lacunarity);
      Inputs.Add(Frequency);
      Inputs.Add(Octaves);
      Inputs.Add(Offset);
    }

    static HeterogeneousMultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<HeterogeneousMultiFractalNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new HeterogeneousMultiFractal();
    }
  }
}
