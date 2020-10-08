﻿using DynamicData;
using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
using NoiseNotIncluded.Util;
using System.Windows.Media;

namespace NoiseNotIncluded.Nodes
{
  public abstract class TransformerNode : NodeWithPreview
  {
    // Power (TurbulenceNode)
    // Rotation (x,y) (RotatePointNode)
    // xModule, yModule, ZModule

    public ValueNodeInputViewModel<IModule> SelectNode { get; } = NodeHelpers.CreateNodeInput("Select");

    // X/Y/Z is only for TurbulenceNode and DisplaceNode
    public ValueNodeInputViewModel<IModule> XNode { get; } = NodeHelpers.CreateNodeInput("X");
    public ValueNodeInputViewModel<IModule> YNode { get; } = NodeHelpers.CreateNodeInput("Y");
    public ValueNodeInputViewModel<IModule> ZNode { get; } = NodeHelpers.CreateNodeInput("Z");

    public TransformerNode() : base()
    {
      Inputs.Add(SelectNode);
    }

    protected static NodeView GetNodeView()
    {
      return new NodeView
      {
        Background = Brushes.Orange
      };
    }
  }
}
