using DynamicData;
using LibNoise;
using LibNoise.Transformer;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Transformers
{
  public class DisplaceNode : TransformerNode
  {
    protected override Transformer.TransformerType TransformerType => Transformer.TransformerType.Displace;

    public DisplaceNode() : base()
    {
      Name = $"Displace_{Uuid()}";

      Inputs.Add(XNode);
      Inputs.Add(YNode);
      Inputs.Add(ZNode);

      RegisterOutputValue(this.WhenAnyObservable(v => v.SelectNode.ValueChanged,
                                                 v => v.XNode.ValueChanged,
                                                 v => v.YNode.ValueChanged,
                                                 v => v.ZNode.ValueChanged,
                                                 (_1, _2, _3, _4) => GetNewOutput()));
    }

    static DisplaceNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<DisplaceNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (SelectNode.Value == null || XNode.Value == null || YNode.Value == null || ZNode.Value == null) return null;

      return new Displace(SelectNode.Value, XNode.Value, YNode.Value, ZNode.Value);
    }
  }
}
