using NodeNetwork.ViewModels;
using System.ComponentModel;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public abstract class NoiseBase
  {
    [PropertyOrder(0)]
    public string name { get; set; } = "Untitled";

    [Browsable(false)]
    public Point pos { get; set; }

    public abstract NodeViewModel CreateModel();
  }
}
