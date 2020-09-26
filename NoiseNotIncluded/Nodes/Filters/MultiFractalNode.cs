using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class MultiFractalNode : FilterNode
  {
    public MultiFractalNode() : base()
    {
      Name = "MultiFractal";
    }

    static MultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MultiFractalNode>));
    }
  }
}
