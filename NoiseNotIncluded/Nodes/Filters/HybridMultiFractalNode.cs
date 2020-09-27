using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Filters
{
  public class HybridMultiFractalNode : FilterNode
  {
    public HybridMultiFractalNode() : base()
    {
      Name = "HybridMultiFractal";
    }

    static HybridMultiFractalNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<HybridMultiFractalNode>));
    }
  }
}
