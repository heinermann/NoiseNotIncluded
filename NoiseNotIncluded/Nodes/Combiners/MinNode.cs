using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MinNode : CombinerNode
  {
    public MinNode() : base()
    {
      Name = "Min";
    }

    static MinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<MinNode>));
    }
  }
}
