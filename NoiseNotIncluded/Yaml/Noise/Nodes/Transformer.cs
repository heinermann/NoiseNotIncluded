using System.Numerics;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Transformer : NoiseBase
  {
	public enum TransformerType
	{
	  _UNSET_,
	  Displace,
	  Turbulence,
	  RotatePoint
	}

	public TransformerType transformerType { get; set; }
	public float power { get; set; }
	public Vector2 rotation { get; set; }

  }
}
