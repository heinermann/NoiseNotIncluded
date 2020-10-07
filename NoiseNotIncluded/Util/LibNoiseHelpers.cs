
using LibNoise;
using LibNoise.Modifier;
using LibNoise.Transformer;
using System.Collections.Generic;

namespace NoiseNotIncluded.Util
{
  public static class LibNoiseHelpers
  {
    public static bool HasLoop(IModule node)
    {
      return HasLoop(node, new HashSet<IModule>());
    }

    public static bool HasLoop(IModule node, params IModule[] initialValues)
    {
      return HasLoop(node, new HashSet<IModule>(initialValues));
    }

    public static bool HasLoop(IModule node, HashSet<IModule> encountered)
    {
      if (node == null) return false;
      if (!encountered.Add(node)) return true;

      switch(node)
      {
        case CombinerModule combiner:
          if (HasLoop(combiner.LeftModule, encountered) || HasLoop(combiner.RightModule)) return true;
          break;
        case FilterModule filter:
          if (HasLoop(filter.Primitive3D, encountered)) return true;
          break;
        case ModifierModule modifier:
          if (HasLoop(modifier.SourceModule, encountered)) return true;
          break;
        case Select select:
          if (HasLoop(select.ControlModule, encountered) || HasLoop(select.LeftModule, encountered) || HasLoop(select.RightModule, encountered)) return true;
          break;
        case Blend blend:
          if (HasLoop(blend.ControlModule, encountered) || HasLoop(blend.LeftModule, encountered) || HasLoop(blend.RightModule, encountered)) return true;
          break;
        case Displace displace:
          if (HasLoop(displace.SourceModule, encountered) ||
            HasLoop(displace.XDisplaceModule, encountered) ||
            HasLoop(displace.YDisplaceModule, encountered) ||
            HasLoop(displace.ZDisplaceModule, encountered))
          {
            return true;
          }
          break;
        case RotatePoint rotate:
          if (HasLoop(rotate.SourceModule, encountered)) return true;
          break;
        case Turbulence turbulence:
          if (HasLoop(turbulence.SourceModule, encountered) ||
            HasLoop(turbulence.XDistortModule, encountered) ||
            HasLoop(turbulence.YDistortModule, encountered) ||
            HasLoop(turbulence.ZDistortModule, encountered))
          {
            return true;
          }
          break;
      }

      encountered.Remove(node);
      return false;
    }
  }
}
