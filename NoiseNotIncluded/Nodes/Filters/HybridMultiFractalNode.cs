using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class HybridMultiFractalNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.HybridMultiFractal;

    // Lacunarity, Frequency, Octaves, Offset, Gain

    public HybridMultiFractalNode() : base()
    {
      Name = $"HybridMultiFractal_{Uuid()}";

      Inputs.Add(Lacunarity);
      Inputs.Add(Frequency);
      Inputs.Add(Octaves);
      Inputs.Add(Offset);
      Inputs.Add(Gain);
    }

    static HybridMultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<HybridMultiFractalNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new HybridMultiFractal();
    }
  }
}
