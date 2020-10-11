using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class CylindersNode : PrimitiveNode
  {
    protected override NoisePrimitive PrimitiveType => NoisePrimitive.Cylinders;

    public CylindersNode() : base()
    {
      Name = "Cylinders";

      Inputs.Add(Offset);
    }

    static CylindersNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<CylindersNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Offset.Value == null) return null;
      return new Cylinders(Offset.Value.Value);
    }
  }
}
