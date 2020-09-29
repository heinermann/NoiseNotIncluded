using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;
using System;
using System.Windows;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class BevinsGradientNode : PrimitiveNode
  {
    public BevinsGradientNode() : base()
    {
      Name = "BevinsGradient";

      Inputs.Add(Quality);
      Inputs.Add(Seed);
    }

    static BevinsGradientNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<BevinsGradientNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Seed.Value == null || Quality.Value == null) return null;

      return new BevinsGradient(Seed.Value.Value, (NoiseQuality)Quality.Value);
    }
  }
}
