using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class SpheresNode : PrimitiveNode
  {
    public SpheresNode() : base()
    {
      Name = "Spheres";
    }

    static SpheresNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SpheresNode>));
    }
  }
}
