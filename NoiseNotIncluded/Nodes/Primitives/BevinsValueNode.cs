using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class BevinsValueNode : PrimitiveNode
  {
    public BevinsValueNode() : base()
    {
      Name = "BevinsValue";
    }

    static BevinsValueNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<BevinsValueNode>));
    }
  }
}
