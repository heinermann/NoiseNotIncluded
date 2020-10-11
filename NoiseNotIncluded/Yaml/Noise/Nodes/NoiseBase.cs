using System.ComponentModel;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class NoiseBase
  {
    [PropertyOrder(0)]
    public string name { get; set; } = "Untitled";

    [Browsable(false)]
    public Point pos { get; set; }
  }
}
