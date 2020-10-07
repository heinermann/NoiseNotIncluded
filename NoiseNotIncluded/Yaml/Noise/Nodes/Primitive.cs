using LibNoise;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Primitive : NoiseBase
  {
    public NoisePrimitive primative { get; set; }
    public NoiseQuality quality { get; set; }
    public int seed { get; set; }
    public float offset { get; set; }
  }
}
