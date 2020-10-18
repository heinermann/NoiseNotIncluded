using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Util;
using NoiseNotIncluded.Yaml;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using System;

namespace NoiseNotIncluded.Nodes
{
  public abstract class NodeWithPreview : NodeViewModel
  {
    OutputPreviewModel OutputPreview { get; } = new OutputPreviewModel();

    public ValueNodeOutputViewModel<IModule> NodeOutput { get; }

    public abstract Link.Type NodeType { get; }

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

    public abstract NoiseBase GetYamlNode();

    public static string Uuid()
    {
      return NodeHelpers.UUID64().Substring(0, 8);
    }
  }
}
