﻿using NodeNetwork.Views;
using ReactiveUI;

namespace NoiseNotIncluded.Nodes.Combiners
{
  public class MaxNode : CombinerNode
  {
    public MaxNode() : base()
    {
      Name = "Max";
    }
    
    static MaxNode()
    {
      Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MaxNode>));
    }
  }
}
