using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class Scale2DNode : ModifierNode
  {
    public Scale2DNode() : base()
    {
      Name = "Scale2D";
    }

    static Scale2DNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<Scale2DNode>));
    }
  }
}
