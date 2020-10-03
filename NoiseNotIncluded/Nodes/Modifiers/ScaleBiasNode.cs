using DynamicData;
using LibNoise;
using LibNoise.Modifier;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ScaleBiasNode : ModifierNode
  {
    public ValueNodeInputViewModel<float?> Scale { get; } = NodeHelpers.CreateFloatEditor("Scale", 1f);
    public ValueNodeInputViewModel<float?> Bias { get; } = NodeHelpers.CreateFloatEditor("Bias", 0f);

    public ScaleBiasNode() : base()
    {
      Name = "ScaleBias";

      Inputs.Add(Scale);
      Inputs.Add(Bias);

      RegisterOutputValue(this.WhenAnyObservable(v => v.NodeInput.ValueChanged,
                                                 v => v.Scale.ValueChanged,
                                                 v => v.Bias.ValueChanged,
                                                 (_1, _2, _3) => GetNewOutput()));
    }

    static ScaleBiasNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ScaleBiasNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null || Scale.Value == null || Bias.Value == null) return null;

      return new ScaleBias(NodeInput.Value, Scale.Value.GetValueOrDefault(1f), Bias.Value.GetValueOrDefault(0f));
    }
  }
}
