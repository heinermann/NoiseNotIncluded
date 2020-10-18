using LibNoise;
using LibNoise.Combiner;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MaxNode : CombinerNode
  {
    protected override Combiner.CombinerType CombineType => Combiner.CombinerType.Max;

    public MaxNode() : base()
    {
      Name = $"Max_{Uuid()}";
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
