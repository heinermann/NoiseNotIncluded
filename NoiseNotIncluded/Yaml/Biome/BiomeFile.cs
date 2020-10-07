using System.Collections.Generic;

namespace NoiseNotIncluded.Yaml.Biome
{
  public class BiomeFile
  {
    public class Merger
    {
      public Dictionary<string, List<ElementGradient>> add { get; set; } = new Dictionary<string, List<ElementGradient>>();
      public List<string> remove { get; set; } = new List<string>();
    }

    public Merger TerrainBiomeLookupTable { get; set; } = new Merger();
  }
}
