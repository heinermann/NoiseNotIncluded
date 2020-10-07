using System.Collections.Generic;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class ControlPointList : NoiseBase
  {
    public class Control
    {
      public float input { get; set; } = 0f;
      public float output { get; set; } = 0f;
    }

    public List<Control> points { get; set; } = new List<Control>();
  }
}
