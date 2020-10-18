using LibNoise;
using LibNoise.Combiner;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class AddNode : CombinerNode
  {
    protected override Combiner.CombinerType CombineType => Combiner.CombinerType.Add;

    public AddNode() : base()
    {
      Name = $"Add_{Uuid()}";
    }

    static AddNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<AddNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Add(LeftInput.Value, RightInput.Value);
    }
  }
}
