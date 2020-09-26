using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class AddNode : CombinerNode
  {
    public AddNode() : base()
    {
      Name = "Add";
    }

    static AddNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AddNode>));
    }
  }
}
