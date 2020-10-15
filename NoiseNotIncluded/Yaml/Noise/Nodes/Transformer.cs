using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
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

    public override NodeViewModel CreateModel()
    {
      TransformerNode result = null;
      switch (transformerType)
      {
        case TransformerType.Displace:
          result = new DisplaceNode();
          break;
        case TransformerType.Turbulence:
          var turbulence = new TurbulenceNode();
          (turbulence.Power.Editor as FloatEditorViewModel).Value = power;
          result = turbulence;
          break;
        case TransformerType.RotatePoint:
          var rotationNode = new RotatePointNode();
          (rotationNode.Rotation.Editor as Vector2EditorViewModel).Value = rotation;
          result = rotationNode;
          break;
      }

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
