using System.Collections.Generic;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class FloatList : NoiseBase
  {
    public List<float> points { get; set; } = new List<float>();
  }
}
