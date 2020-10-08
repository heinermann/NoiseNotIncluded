using DynamicData;
using LibNoise;
using LibNoise.Transformer;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;
using System.Numerics;

namespace NoiseNotIncluded.Nodes.Transformers
{
  public class RotatePointNode : TransformerNode
  {
    public ValueNodeInputViewModel<Vector2> Rotation { get; } = NodeHelpers.CreateVector2Editor("Rotation", 0f, 0f);

    public RotatePointNode() : base()
    {
      Name = "RotatePoint";

      Inputs.Add(Rotation);

      RegisterOutputValue(this.WhenAnyObservable(v => v.SelectNode.ValueChanged,
                                           v => v.Rotation.ValueChanged,
                                           (_1, _2) => GetNewOutput()));
    }

    static RotatePointNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<RotatePointNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (SelectNode.Value == null || Rotation.Value == null) return null;

      return new RotatePoint(SelectNode.Value, Rotation.Value.X, Rotation.Value.Y, 0f);
    }
  }
}
