using LibNoise;
using LibNoise.Combiner;
using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class AddNode : CombinerNode
  {
    public AddNode() : base()
    {
      Name = "Add";


    }

    static AddNode()
    {
      Splat.Locator.CurrentMutable.Register(() => GetNodeView(), typeof(IViewFor<AddNode>));
    }

    protected override IModule GetNewOutput()
    {
      if (LeftInput.Value == null || RightInput.Value == null) return null;

      return new Add(LeftInput.Value, RightInput.Value);
    }
  }
}
