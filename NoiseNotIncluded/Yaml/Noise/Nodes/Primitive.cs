using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Primitives;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Primitive : NoiseBase
  {
    public NoisePrimitive primative { get; set; }
    public NoiseQuality? quality { get; set; }
    public int? seed { get; set; }
    public float? offset { get; set; }

    public override NodeViewModel CreateModel()
    {
      PrimitiveNode result = null;
      switch (primative)
      {
        case NoisePrimitive.Constant:
          result = new ConstantNode();
          break;
        case NoisePrimitive.Spheres:
          result = new SpheresNode();
          break;
        case NoisePrimitive.Cylinders:
          result = new CylindersNode();
          break;
        case NoisePrimitive.BevinsValue:
          result = new BevinsValueNode();
          break;
        case NoisePrimitive.BevinsGradient:
          result = new BevinsGradientNode();
          break;
        case NoisePrimitive.ImprovedPerlin:
          result = new ImprovedPerlinNode();
          break;
        case NoisePrimitive.SimplexPerlin:
          result = new SimplexPerlinNode();
          break;
      }
      (result.Quality.Editor as EnumEditorViewModel).Value = quality;
      (result.Seed.Editor as ValueEditorViewModel<int?>).Value = seed;
      (result.Offset.Editor as FloatEditorViewModel).Value = offset;

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
