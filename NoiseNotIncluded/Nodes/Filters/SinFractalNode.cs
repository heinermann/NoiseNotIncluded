using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class SinFractalNode : FilterNode
  {
    public SinFractalNode() : base()
    {
      Name = "SinFractal";
    }

    static SinFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<SinFractalNode>));
    }
  }
}
