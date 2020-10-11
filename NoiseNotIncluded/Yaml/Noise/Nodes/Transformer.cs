using NodeNetwork.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Transformers;
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
	public float? power { get; set; }
	public Vector2 rotation { get; set; }

    public NodeViewModel CreateModel()
    {
      TransformerNode result = null;
      switch (transformerType)
      {
        case TransformerType.Displace:
          result = new DisplaceNode();
          break;
        case TransformerType.Turbulence:
          // TODO: Args
          var turbulence = new TurbulenceNode();
          result = turbulence;
          break;
        case TransformerType.RotatePoint:
          // TODO: Args
          result = new RotatePointNode();
          break;
      }

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
