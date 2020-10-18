using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class PipeNode : FilterNode
  {
    protected override NoiseFilter FilterType => NoiseFilter.Pipe;

    // Frequency

    public PipeNode() : base()
    {
      Name = $"Pipe_{Uuid()}";

      Inputs.Add(Frequency);
    }

    static PipeNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<PipeNode>));
    }

    protected override IModule GetNewOutput()
    {
      return new Pipe();
    }
  }
}
