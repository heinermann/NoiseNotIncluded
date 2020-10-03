using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using NoiseNotIncluded.Util;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public abstract class FilterNode : NodeWithPreview
  {
    // Frequency
    // Lacunarity
    // OctaveCount (as Octaves in ONI)
    // Offset
    // Gain
    // 
    // Uses Primitive3D

    public ValueNodeInputViewModel<float?> Frequency { get; } = NodeHelpers.CreateFloatEditor("Frequency", 1f);
    public ValueNodeInputViewModel<float?> Lacunarity { get; } = NodeHelpers.CreateFloatEditor("Lacunarity", 2f);
    public ValueNodeInputViewModel<int?> Octaves { get; } = NodeHelpers.CreateIntEditor("Octaves", 6);
    public ValueNodeInputViewModel<float?> Offset { get; } = NodeHelpers.CreateFloatEditor("Offset", 1f);
    public ValueNodeInputViewModel<float?> Gain { get; } = NodeHelpers.CreateFloatEditor("Gain", 2f);

    public ValueNodeInputViewModel<IModule> NodeInput { get; } = NodeHelpers.CreateNodeInput("Input");

    public FilterNode()
    {
      RegisterOutputValue(this.WhenAnyObservable(
        v => v.Frequency.ValueChanged,
        v => v.Lacunarity.ValueChanged,
        v => v.Octaves.ValueChanged,
        v => v.Offset.ValueChanged,
        v => v.Gain.ValueChanged,
        v => v.NodeInput.ValueChanged,
        (_1, _2, _3, _4, _5, _6) => GetNewFilterOutput()));

      Inputs.Add(NodeInput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Purple
      };
    }

    protected IModule GetNewFilterOutput()
    {
      if (NodeInput.Value == null) return null;
      if (Lacunarity.Value == null || Frequency.Value == null || Octaves.Value == null) return null;

      FilterModule filter = GetNewOutput() as FilterModule;
      filter.Frequency = Frequency.Value.GetValueOrDefault(1f);
      filter.Lacunarity = Lacunarity.Value.GetValueOrDefault(2f);
      filter.OctaveCount = Octaves.Value.GetValueOrDefault(6);
      filter.Offset = Offset.Value.GetValueOrDefault(1f);
      filter.Gain = Gain.Value.GetValueOrDefault(2f);

      filter.Primitive3D = NodeInput.Value as IModule3D;
      return filter;
    }
  }
}
