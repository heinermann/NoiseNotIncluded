using LibNoise;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Filter : NoiseBase
  {
    public NoiseFilter filter { get; set; }
    public float frequency { get; set; }
    public float lacunarity { get; set; }
    public int octaves { get; set; }
    public float offset { get; set; }
    public float gain { get; set; }
    public float exponent { get; set; }
  }
}
