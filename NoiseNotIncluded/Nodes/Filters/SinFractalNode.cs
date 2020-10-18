using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class SinFractalNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.SinFractal;

    // Lacunarity, Frequency, Octaves

    public SinFractalNode() : base()
    {
      Name = $"SinFractal_{Uuid()}";

      Inputs.Add(Lacunarity);
      Inputs.Add(Frequency);
      Inputs.Add(Octaves);
    }

    static SinFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<SinFractalNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new SinFractal();
    }
  }
}
