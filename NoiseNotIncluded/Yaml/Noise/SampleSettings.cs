
using NoiseNotIncluded.Yaml.Noise.Nodes;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace NoiseNotIncluded.Yaml
{
  public class SampleSettings : NoiseBase
  {
    [PropertyOrder(5)]
    public float zoom { get; set; } = 0.1f;
    
    [PropertyOrder(6)]
    public bool normalise { get; set; } = false;
    
    [PropertyOrder(7)]
    public bool seamless { get; set; } = false;
    
    [ExpandableObject()]
    [PropertyOrder(8)]
    public Point lowerBound { get; set; } = new Point(2, 2);

    [ExpandableObject()]
    [PropertyOrder(9)]
    public Point upperBound { get; set; } = new Point(4, 4);
  }
}
