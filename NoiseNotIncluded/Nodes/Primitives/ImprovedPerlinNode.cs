using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class ImprovedPerlinNode : PrimitiveNode
  {
    public ImprovedPerlinNode() : base()
    {
      Name = "ImprovedPerlin";

      Inputs.Add(Quality);
      Inputs.Add(Seed);
    }

    static ImprovedPerlinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ImprovedPerlinNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Seed.Value == null || Quality.Value == null) return null;
      return new ImprovedPerlin(Seed.Value.Value, (NoiseQuality)Quality.Value);
    }
  }
}
