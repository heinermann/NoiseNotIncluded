using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Util;
using System;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public abstract class PrimitiveNode : NodeViewModel
  {
    // Quality (LibNoise.NoiseQuality [Fast, Standard, Best]) (Bevins*, *Perlin)
    // Seed (Bevins*, *Perlin)
    // Offset (Only Constant, Cylinders, and Spheres)
    // 
    public ValueNodeInputViewModel<object> Quality { get; } = new ValueNodeInputViewModel<object>()
    {
      Name = "Quality",
      Editor = new EnumEditorViewModel(typeof(NoiseQuality))
    };

    public ValueNodeInputViewModel<int?> Seed { get; } = new ValueNodeInputViewModel<int?>()
    {
      Name = "Seed",
      Editor = new IntegerEditorViewModel()
    };

    public ValueNodeInputViewModel<float?> Offset { get; } = new ValueNodeInputViewModel<float?>()
    {
      Name = "Offset",
      Editor = new FloatEditorViewModel()
    };

    public ValueNodeOutputViewModel<IModule> NodeOutput { get; }

    OutputPreviewModel OutputPreview { get; } = new OutputPreviewModel();

    public PrimitiveNode()
    {
      NodeOutput = new ValueNodeOutputViewModel<IModule>()
      {
        Name = "Output",
        Value = this.WhenAnyObservable(x => x.Quality.ValueChanged, x => x.Seed.ValueChanged, x => x.Offset.ValueChanged, (o1, o2, o3) => GetNewOutput()),
        Editor = OutputPreview
      };

      NodeOutput.Value.Subscribe(module => OutputPreview.Value = module);

      Quality.Port.IsVisible = false;
      Seed.Port.IsVisible = false;
      Offset.Port.IsVisible = false;

      Outputs.Add(NodeOutput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Red
      };
    }

    protected abstract IModule GetNewOutput();
  }
}
