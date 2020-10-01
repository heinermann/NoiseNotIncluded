using NodeNetwork.ViewModels;
using NodeNetwork.Toolkit.ValueNode;
using DynamicData;
using ReactiveUI;
using System.Reactive.Linq;
using NodeNetwork.Views;
using System.Windows.Media;
using LibNoise;
using NodeNetworkExtensions.ViewModels;
using System;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public abstract class CombinerNode : NodeViewModel
  {
    public ValueNodeInputViewModel<IModule> LeftInput { get; } = new ValueNodeInputViewModel<IModule>()
    {
      Name = "Left"
    };

    public ValueNodeInputViewModel<IModule> RightInput { get; } = new ValueNodeInputViewModel<IModule>()
    {
      Name = "Right"
    };

    public ValueNodeOutputViewModel<IModule> NodeOutput { get; }

    OutputPreviewModel OutputPreview { get; } = new OutputPreviewModel();

    public CombinerNode()
    {
      NodeOutput = new ValueNodeOutputViewModel<IModule>()
      {
        Name = "Output",
        Value = this.WhenAnyObservable(vm => vm.LeftInput.ValueChanged, vm => vm.RightInput.ValueChanged)
                  .Select(v => GetNewOutput()),
        Editor = OutputPreview
      };

      NodeOutput.Value.Subscribe(module => OutputPreview.Value = module);

      Inputs.Add(LeftInput);
      Inputs.Add(RightInput);

      Outputs.Add(NodeOutput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Teal
      };
    }

    protected abstract IModule GetNewOutput();
  }
}
