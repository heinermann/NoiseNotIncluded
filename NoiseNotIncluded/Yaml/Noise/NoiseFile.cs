
using NoiseNotIncluded.Yaml.Noise.Nodes;
using System.Collections.Generic;

namespace NoiseNotIncluded.Yaml
{
  public class NoiseFile
  {
    public SampleSettings settings { get; set; } = new SampleSettings();
    public List<NodeLink> links { get; set; } = new List<NodeLink>();
    public Dictionary<string, Primitive> primitives { get; set; } = new Dictionary<string, Primitive>();
    public Dictionary<string, Filter> filters { get; set; } = new Dictionary<string, Filter>();
    public Dictionary<string, Transformer> transformers { get; set; } = new Dictionary<string, Transformer>();
    public Dictionary<string, Selector> selectors { get; set; } = new Dictionary<string, Selector>();
    public Dictionary<string, Modifier> modifiers { get; set; } = new Dictionary<string, Modifier>();
    public Dictionary<string, Combiner> combiners { get; set; } = new Dictionary<string, Combiner>();
    public Dictionary<string, FloatList> floats { get; set; } = new Dictionary<string, FloatList>();
    public Dictionary<string, ControlPointList> controlpoints { get; set; } = new Dictionary<string, ControlPointList>();

    public void ClearLists()
    {
      links.Clear();
      primitives.Clear();
      filters.Clear();
      transformers.Clear();
      selectors.Clear();
      modifiers.Clear();
      combiners.Clear();
      floats.Clear();
      controlpoints.Clear();
    }
  }
}
