using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class SimplexPerlinNode : PrimitiveNode
  {
    public SimplexPerlinNode() : base()
    {
      Name = "SimplexPerlin";

      Inputs.Add(Quality);
      Inputs.Add(Seed);
    }

    static SimplexPerlinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<SimplexPerlinNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Seed.Value == null || Quality.Value == null) return null;
      return new SimplexPerlin(Seed.Value.Value, (NoiseQuality)Quality.Value);
    }
  }
}
