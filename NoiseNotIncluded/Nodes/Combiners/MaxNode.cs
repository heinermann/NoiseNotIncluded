using LibNoise;
using LibNoise.Combiner;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MaxNode : CombinerNode
  {
    public MaxNode() : base()
    {
      Name = "Max";
    }
    
    static MaxNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<MaxNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Max(LeftInput.Value, RightInput.Value);
    }
  }
}
