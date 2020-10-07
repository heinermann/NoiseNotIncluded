using System.Numerics;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Modifier : NoiseBase
  {
	public enum ModifyType
	{
	  _UNSET_,
	  Abs,
	  Clamp,
	  Exponent,
	  Invert,
	  ScaleBias,
	  Scale2d,
	  Curve,
	  Terrace
	}

	public ModifyType modifyType { get; set; }
	public float lower { get; set; }
	public float upper { get; set; }
	public float exponent { get; set; }
	public bool invert { get; set; }
	public float scale { get; set; }
	public float bias { get; set; }
	public Vector2 scale2d { get; set; }
  }
}
