using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using NoiseNotIncluded.Util;
using NoiseNotIncluded.Yaml;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public abstract class PrimitiveNode : NodeWithPreview
  {
    // Quality (LibNoise.NoiseQuality [Fast, Standard, Best]) (Bevins*, *Perlin)
    // Seed (Bevins*, *Perlin)
    // Offset (Only Constant, Cylinders, and Spheres)
    // 
    public ValueNodeInputViewModel<object> Quality { get; } = NodeHelpers.CreateEnumEditor("Quality", typeof(NoiseQuality));
    public ValueNodeInputViewModel<int?> Seed { get; } = NodeHelpers.CreateIntEditor("Seed", 0);
    public ValueNodeInputViewModel<float?> Offset { get; } = NodeHelpers.CreateFloatEditor("Offset", 1f);

    protected abstract NoisePrimitive PrimitiveType { get; }
    public override Link.Type NodeType => Link.Type.Primitive;

    public PrimitiveNode() : base()
    {
      RegisterOutputValue(this.WhenAnyObservable(
        x => x.Quality.ValueChanged,
        x => x.Seed.ValueChanged,
        x => x.Offset.ValueChanged,
        (o1, o2, o3) => GetNewOutput()));
    }

    protected static NodeView GetNodeView()
    {
      return NodeHelpers.CreateNodeView(Brushes.Red);
    }

    public override NoiseBase GetYamlNode()
    {
      return new Primitive()
      {
        primative = this.PrimitiveType,
        name = this.Name,
        pos = this.Position,
        offset = Offset.Value,
        quality = Quality.Value as NoiseQuality?,
        seed = Seed.Value
      };
    }
  }
}
