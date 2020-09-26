using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class PipeNode : FilterNode
  {
    public PipeNode() : base()
    {
      Name = "Pipe";
    }

    static PipeNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PipeNode>));
    }
  }
}
