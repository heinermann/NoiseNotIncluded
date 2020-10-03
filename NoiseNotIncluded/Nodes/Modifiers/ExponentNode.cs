using DynamicData;
using LibNoise;
using LibNoise.Modifier;
using NodeNetwork.Toolkit.ValueNode;
using NoiseNotIncluded.Util;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class ExponentNode : ModifierNode
  {
    public ValueNodeInputViewModel<float?> Exponent { get; } = NodeHelpers.CreateFloatEditor("Exponent", 0.02f);

    public ExponentNode() : base()
    {
      Name = "Exponent";
      
      Inputs.Add(Exponent);

      RegisterOutputValue(this.WhenAnyObservable(v => v.NodeInput.ValueChanged,
                                                 v => v.Exponent.ValueChanged,
                                                 (_1, _2) => GetNewOutput()));
    }

    static ExponentNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<ExponentNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (NodeInput.Value == null || Exponent.Value == null) return null;

      return new Exponent(NodeInput.Value, Exponent.Value.GetValueOrDefault(0.02f));
    }
  }
}
