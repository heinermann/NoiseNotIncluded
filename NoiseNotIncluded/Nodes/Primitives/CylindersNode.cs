using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Primitives
{
  public class CylindersNode : PrimitiveNode
  {
    public CylindersNode() : base()
    {
      Name = "Cylinders";
    }

    static CylindersNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<CylindersNode>));
    }
  }
}
