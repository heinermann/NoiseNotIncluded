using LibNoise;
using LibNoise.Combiner;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MinNode : CombinerNode
  {
    public MinNode() : base()
    {
      Name = "Min";
    }

    static MinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<MinNode>));
    }
    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Min(LeftInput.Value, RightInput.Value);
    }
  }
}
