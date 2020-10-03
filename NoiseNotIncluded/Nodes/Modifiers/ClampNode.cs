using DynamicData;
using LibNoise;
using LibNoise.Modifier;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ClampNode : ModifierNode
  {
    public ValueNodeInputViewModel<float?> Lower { get; } = NodeHelpers.CreateFloatEditor("Lower", -1f);
    public ValueNodeInputViewModel<float?> Upper { get; } = NodeHelpers.CreateFloatEditor("Upper", 1f);

    public ClampNode() : base()
    {
      Name = "Clamp";

      Inputs.Add(Lower);
      Inputs.Add(Upper);

      RegisterOutputValue(this.WhenAnyObservable(v => v.NodeInput.ValueChanged,
                                                 v => v.Lower.ValueChanged,
                                                 v => v.Upper.ValueChanged,
                                                 (_1, _2, _3) => GetNewOutput()));
    }

    static ClampNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ClampNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null || Lower.Value == null || Upper.Value == null) return null;

      return new Clamp(NodeInput.Value, Lower.Value.GetValueOrDefault(-1f), Upper.Value.GetValueOrDefault(1f));
    }
  }
}
