
using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using NodeNetworkExtensions.ViewModels;
using System.Reactive.Linq;
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
      Editor = new IntegerValueEditorViewModel()
    };

    // TODO: This should be float
    public ValueNodeInputViewModel<int?> Offset { get; } = new ValueNodeInputViewModel<int?>()
    {
      Name = "Offset",
      Editor = new IntegerValueEditorViewModel()
    };

    public ValueNodeOutputViewModel<IModule> NodeOutput { get; }

    public PrimitiveNode()
    {
      NodeOutput = new ValueNodeOutputViewModel<IModule>()
      {
        Name = "Output",
        Value = Observable.Return(GetNewOutput()) // TODO: Make this update based on changes
      };

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
