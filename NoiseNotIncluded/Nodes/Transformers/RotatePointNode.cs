using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Transformers
{
  public class RotatePointNode : TransformerNode
  {
    public RotatePointNode() : base()
    {
      Name = "RotatePoint";
    }

    static RotatePointNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<RotatePointNode>));
    }
  }
}
