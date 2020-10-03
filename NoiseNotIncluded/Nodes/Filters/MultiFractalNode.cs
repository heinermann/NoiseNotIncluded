using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class MultiFractalNode : FilterNode
  {
    // Lacunarity, Frequency, Octaves, Offset

    public MultiFractalNode() : base()
    {
      Name = "MultiFractal";

      Inputs.Add(Lacunarity);
      Inputs.Add(Frequency);
      Inputs.Add(Octaves);
      Inputs.Add(Offset);
    }

    static MultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<MultiFractalNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new MultiFractal();
    }
  }
}
