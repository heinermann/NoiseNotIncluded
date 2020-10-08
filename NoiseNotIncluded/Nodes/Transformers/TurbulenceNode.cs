using DynamicData;
using LibNoise;
using LibNoise.Transformer;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Transformers
{
  public class TurbulenceNode : TransformerNode
  {
    public ValueNodeInputViewModel<float?> Power { get; } = NodeHelpers.CreateFloatEditor("Power", 1f);

    public TurbulenceNode() : base()
    {
      Name = "Turbulence";

      Inputs.Add(XNode);
      Inputs.Add(YNode);
      Inputs.Add(ZNode);
      Inputs.Add(Power);

      RegisterOutputValue(this.WhenAnyObservable(v => v.SelectNode.ValueChanged,
                                                 v => v.XNode.ValueChanged,
                                                 v => v.YNode.ValueChanged,
                                                 v => v.ZNode.ValueChanged,
                                                 v => v.Power.ValueChanged,
                                                 (_1, _2, _3, _4, _5) => GetNewOutput()));
    }

    static TurbulenceNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<TurbulenceNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (SelectNode.Value == null || XNode.Value == null || YNode.Value == null || ZNode.Value == null || Power.Value == null) return null;

      return new Turbulence(SelectNode.Value, XNode.Value, YNode.Value, ZNode.Value, Power.Value.GetValueOrDefault(1f));
    }
  }
}
