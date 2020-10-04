using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;
using System.Numerics;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class Scale2DNode : ModifierNode
  {
    public ValueNodeInputViewModel<Vector2> Scale2d { get; } = NodeHelpers.CreateVector2Editor("Scale2d", 1f, 1f);

    public Scale2DNode() : base()
    {
      Name = "Scale2D";

      Inputs.Add(Scale2d);

      RegisterOutputValue(this.WhenAnyObservable(
        v => v.NodeInput.ValueChanged,
        v => v.Scale2d.ValueChanged,
        (_1, _2) => GetNewOutput()));
    }

    static Scale2DNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<Scale2DNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null) return null;

      return new Scale2d(NodeInput.Value, Scale2d.Value);
    }
  }
}
