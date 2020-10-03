
using LibNoise;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public class Scale2d : ModifierModule, IModule3D, IModule
  {
    public Vector2 Scale { get; set; } = new Vector2(1f, 1f);

    public Scale2d() { }

    public Scale2d(IModule source) : base(source) { }

    public Scale2d(IModule source, Vector2 scale) : base(source)
    {
      this.Scale = scale;
    }

    public float GetValue(float x, float y, float z)
    {
      return ((IModule3D)this.SourceModule).GetValue(x * Scale.x, y, z * Scale.y);
    }
  }
}
