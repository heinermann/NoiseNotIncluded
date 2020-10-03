using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using System;

namespace NoiseNotIncluded.Nodes
{
  public abstract class NodeWithPreview : NodeViewModel
  {
    OutputPreviewModel OutputPreview { get; } = new OutputPreviewModel();

    public ValueNodeOutputViewModel<IModule> NodeOutput { get; }

    public NodeWithPreview() : base()
    {
      NodeOutput = new ValueNodeOutputViewModel<IModule>()
      {
        Name = "Output",
        Editor = OutputPreview
      };

      Outputs.Add(NodeOutput);
    }

    public void RegisterOutputValue(IObservable<IModule> observable)
    {
      NodeOutput.Value = observable;
      NodeOutput.Value.Subscribe(module => OutputPreview.Value = module);
    }

    protected abstract IModule GetNewOutput();
  }
}
