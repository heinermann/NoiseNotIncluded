using LibNoise;
using LibNoise.Combiner;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MultiplyNode : CombinerNode
  {
    protected override Combiner.CombinerType CombineType => Combiner.CombinerType.Multiply;

    public MultiplyNode() : base()
    {
      Name = $"Multiply_{Uuid()}";
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
