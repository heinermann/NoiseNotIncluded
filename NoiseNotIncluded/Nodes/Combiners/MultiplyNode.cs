using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MultiplyNode : CombinerNode
  {
    public MultiplyNode() : base()
    {
      Name = "Multiply";
    }

    static MultiplyNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MultiplyNode>));
    }
  }
}
