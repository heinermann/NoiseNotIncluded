
using NoiseNotIncluded.Yaml.Noise.Nodes;
using System.Numerics;

namespace NoiseNotIncluded.Yaml
{
  public class SampleSettings : NoiseBase
  {
    public float zoom { get; set; } = 0.1f;
    public bool normalise { get; set; } = false;
    public bool seamless { get; set; } = false;
    public Vector2 lowerBound { get; set; } = new Vector2(2, 2);
    public Vector2 upperBound { get; set; } = new Vector2(4, 4);
  }
}
