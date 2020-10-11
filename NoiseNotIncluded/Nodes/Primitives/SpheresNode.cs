using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class SpheresNode : PrimitiveNode
  {
    protected override NoisePrimitive PrimitiveType => NoisePrimitive.Spheres;

    public SpheresNode() : base()
    {
      Name = "Spheres";

      Inputs.Add(Offset);
    }

    static SpheresNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<SpheresNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Offset.Value == null) return null;
      return new Spheres(Offset.Value.Value);
    }
  }
}
