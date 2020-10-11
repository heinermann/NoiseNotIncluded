using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class SumFractalNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.SumFractal;

    // Lacunarity, Frequency, Octaves

    public SumFractalNode() : base()
    {
      Name = "SumFractal";

      Inputs.Add(Lacunarity);
      Inputs.Add(Frequency);
      Inputs.Add(Octaves);
    }

    static SumFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<SumFractalNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new SumFractal();
    }
  }
}
