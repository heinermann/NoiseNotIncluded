using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Filters;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Filter : NoiseBase
  {
    public NoiseFilter filter { get; set; }
    public float? frequency { get; set; }
    public float? lacunarity { get; set; }
    public int? octaves { get; set; }
    public float? offset { get; set; }
    public float? gain { get; set; }
    public float? exponent { get; set; }

    public override NodeViewModel CreateModel()
    {
      FilterNode result = null;
      switch (filter)
      {
        case NoiseFilter.Pipe:
          result = new PipeNode();
          break;
        case NoiseFilter.SumFractal:
          result = new SumFractalNode();
          break;
        case NoiseFilter.SinFractal:
          result = new SinFractalNode();
          break;
        case NoiseFilter.Billow:
          result = new BillowNode();
          break;
        case NoiseFilter.MultiFractal:
          result = new MultiFractalNode();
          break;
        case NoiseFilter.HeterogeneousMultiFractal:
          result = new HeterogeneousMultiFractalNode();
          break;
        case NoiseFilter.HybridMultiFractal:
          result = new HybridMultiFractalNode();
          break;
        case NoiseFilter.RidgedMultiFractal:
          result = new RidgedMultiFractalNode();
          break;
        case NoiseFilter.Voronoi:
          result = new VoronoiNode();
          break;
      }

      (result.Frequency.Editor as FloatEditorViewModel).Value = frequency;
      (result.Lacunarity.Editor as FloatEditorViewModel).Value = lacunarity;
      (result.Octaves.Editor as ValueEditorViewModel<int?>).Value = octaves;
      (result.Offset.Editor as FloatEditorViewModel).Value = offset;
      (result.Gain.Editor as FloatEditorViewModel).Value = gain;

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
