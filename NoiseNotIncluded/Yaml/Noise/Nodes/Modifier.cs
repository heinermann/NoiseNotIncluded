using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Modifiers;
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
	public float? lower { get; set; }
	public float? upper { get; set; }
	public float? exponent { get; set; }
	public bool? invert { get; set; }
	public float? scale { get; set; }
	public float? bias { get; set; }
	public Vector2 scale2d { get; set; }

    public NodeViewModel CreateModel()
    {
      ModifierNode result = null;
      switch (modifyType)
      {
        case ModifyType.Abs:
          result = new AbsNode();
          break;
        case ModifyType.Clamp:
          var clampNode = new ClampNode();
          (clampNode.Lower.Editor as FloatEditorViewModel).Value = lower;
          (clampNode.Upper.Editor as FloatEditorViewModel).Value = upper;
          result = clampNode;
          break;
        case ModifyType.Exponent:
          var exponentNode = new ExponentNode();
          (exponentNode.Exponent.Editor as FloatEditorViewModel).Value = exponent;
          result = exponentNode;
          break;
        case ModifyType.Invert:
          result = new InvertNode();
          break;
        case ModifyType.ScaleBias:
          var scaleBiasNode = new ScaleBiasNode();
          (scaleBiasNode.Scale.Editor as FloatEditorViewModel).Value = scale;
          (scaleBiasNode.Bias.Editor as FloatEditorViewModel).Value = bias;
          result = scaleBiasNode;
          break;
        case ModifyType.Scale2d:
          var scale2dNode = new Scale2DNode();
          (scale2dNode.Scale2d.Editor as ValueEditorViewModel<Vector2>).Value = scale2d;
          result = scale2dNode;
          break;
        case ModifyType.Curve:
          result = new CurveNode();
          // TODO
          break;
        case ModifyType.Terrace:
          result = new TerraceNode();
          // TODO
          break;
      }

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
