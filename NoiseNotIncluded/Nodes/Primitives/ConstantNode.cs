using DynamicData;
using LibNoise;
using LibNoise.Primitive;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class ConstantNode : PrimitiveNode
  {
    protected override NoisePrimitive PrimitiveType => NoisePrimitive.Constant;

    public ConstantNode() : base()
    {
      Name = "Constant";

      Inputs.Add(Offset);

      // Disable preview
      NodeOutput.Editor = null;
    }

    static ConstantNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ConstantNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (Offset.Value == null) return null;
      return new Constant(Offset.Value.Value);
    }
  }
}
