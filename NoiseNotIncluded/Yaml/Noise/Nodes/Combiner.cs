namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Combiner : NoiseBase
  {
	public enum CombinerType
	{
	  _UNSET_,
	  Add,
	  Max,
	  Min,
	  Multiply,
	  Power
	}

	public CombinerType combineType { get; set; }
  }
}
