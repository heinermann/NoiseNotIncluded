namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Selector : NoiseBase
  {
	public enum SelectType
	{
	  _UNSET_,
	  Blend,
	  Select
	}

	public SelectType selectType { get; set; }
	public float? lower { get; set; }
	public float? upper { get; set; }
	public float? edge { get; set; }

  }
}
