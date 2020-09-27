using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class ImprovedPerlinNode : PrimitiveNode
  {
    public ImprovedPerlinNode() : base()
    {
      Name = "ImprovedPerlin";
    }

    static ImprovedPerlinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ImprovedPerlinNode>));
    }
  }
}
