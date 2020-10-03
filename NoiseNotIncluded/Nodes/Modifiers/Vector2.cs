using System;

namespace NoiseNotIncluded.Nodes.Modifiers
{
  public struct Vector2 : IEquatable<Vector2>
  {
    public float x, y;

    public Vector2(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    public override int GetHashCode()
    {
      return x.GetHashCode() ^ (y.GetHashCode() << 2);
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Vector2))
      {
        return false;
      }
      return Equals((Vector2)obj);
    }

    public bool Equals(Vector2 other)
    {
      return x.Equals(other.x) && y.Equals(other.y);
    }
  }
}
