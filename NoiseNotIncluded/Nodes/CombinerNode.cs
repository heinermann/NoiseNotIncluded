using NodeNetwork.Toolkit.ValueNode;
using DynamicData;
using ReactiveUI;
using System.Reactive.Linq;
using NodeNetwork.Views;
using System.Windows.Media;
using LibNoise;
using System;
using NoiseNotIncluded.Util;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using NoiseNotIncluded.Yaml;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public abstract class CombinerNode : NodeWithPreview
  {
    public ValueNodeInputViewModel<IModule> LeftInput { get; } = NodeHelpers.CreateNodeInput("Left");
    public ValueNodeInputViewModel<IModule> RightInput { get; } = NodeHelpers.CreateNodeInput("Right");

    protected abstract Combiner.CombinerType CombineType { get; }
    public override Link.Type NodeType => Link.Type.Combiner;

    public CombinerNode()
    {
      RegisterOutputValue(this.WhenAnyObservable(vm => vm.LeftInput.ValueChanged, vm => vm.RightInput.ValueChanged)
                  .Select(v => GetNewOutput()));

      Inputs.Add(LeftInput);
      Inputs.Add(RightInput);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Teal
      };
    }

    public override NoiseBase GetYamlNode()
    {
      return new Combiner()
      {
        combineType = this.CombineType,
        name = this.Name,
        pos = this.Position
      };
    }
  }
}
