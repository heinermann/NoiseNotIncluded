using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class PowerNode : CombinerNode
  {
    public PowerNode() : base()
    {
      Name = "Power";
    }

    static PowerNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PowerNode>));
    }
  }
}
