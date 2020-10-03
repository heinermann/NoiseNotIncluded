using LibNoise;
using LibNoise.Modifier;
using ReactiveUI;
using System.Reactive.Linq;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class InvertNode : ModifierNode
  {
    public InvertNode() : base()
    {
      Name = "Invert";

      RegisterOutputValue(NodeInput.ValueChanged.Select(v => GetNewOutput()));
    }

    static InvertNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<InvertNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null) return null;
      return new Invert(NodeInput.Value);
    }
  }
}
