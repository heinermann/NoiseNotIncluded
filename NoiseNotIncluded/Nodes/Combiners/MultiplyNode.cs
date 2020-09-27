using LibNoise;
using LibNoise.Combiner;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MultiplyNode : CombinerNode
  {
    public MultiplyNode() : base()
    {
      Name = "Multiply";
    }

    static MultiplyNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<MultiplyNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Multiply(LeftInput.Value, RightInput.Value);
    }
  }
}
