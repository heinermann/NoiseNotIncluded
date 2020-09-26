using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class SimplexPerlinNode : PrimitiveNode
  {
    public SimplexPerlinNode() : base()
    {
      Name = "SimplexPerlin";
    }

    static SimplexPerlinNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SimplexPerlinNode>));
    }
  }
}
