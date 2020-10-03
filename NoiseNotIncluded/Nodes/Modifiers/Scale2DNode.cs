using LibNoise;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  // TODO
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

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null) return null;

      return new Scale2d(NodeInput.Value);
    }
  }
}
