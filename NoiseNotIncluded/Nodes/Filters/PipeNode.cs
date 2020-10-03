using DynamicData;
using LibNoise;
using LibNoise.Filter;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class PipeNode : FilterNode
  {
    // Frequency

    public PipeNode() : base()
    {
      Name = "Pipe";

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
