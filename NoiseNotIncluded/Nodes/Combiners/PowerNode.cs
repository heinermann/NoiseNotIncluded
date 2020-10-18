using LibNoise;
using LibNoise.Combiner;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class PowerNode : CombinerNode
  {
    protected override Combiner.CombinerType CombineType => Combiner.CombinerType.Power;

    public PowerNode() : base()
    {
      Name = $"Power_{Uuid()}";
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
