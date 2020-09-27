using LibNoise;
using LibNoise.Combiner;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class PowerNode : CombinerNode
  {
    public PowerNode() : base()
    {
      Name = "Power";
    }

    static PowerNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<PowerNode>));
    }
    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Power(LeftInput.Value, RightInput.Value);
    }
  }
}
