using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetworkExtensions.ViewModels;
using System;
using System.Numerics;

namespace NoiseNotIncluded.Util
{
  public static class NodeHelpers
  {
    public static ValueNodeInputViewModel<int?> CreateIntEditor(string name, int defaultValue = 1)
    {
      var editor = new IntegerEditorViewModel()
      {
        Value = defaultValue
      };

      var result = new ValueNodeInputViewModel<int?>()
      {
        Name = name,
        Editor = editor,
        MaxConnections = 0
      };
      result.Port.IsVisible = false;
      return result;
    }

    public static ValueNodeInputViewModel<float?> CreateFloatEditor(string name, float defaultValue = 1f)
    {
      var editor = new FloatEditorViewModel()
      {
        Value = defaultValue
      };

      var result = new ValueNodeInputViewModel<float?>()
      {
        Name = name,
        Editor = editor,
        MaxConnections = 0
      };
      result.Port.IsVisible = false;
      return result;
    }

    public static ValueNodeInputViewModel<Vector2> CreateVector2Editor(string name, float defaultX = 1f, float defaultY = 1f)
    {
      var editor = new Vector2EditorViewModel()
      {
        Value = new Vector2(defaultX, defaultY)
      };

      var result = new ValueNodeInputViewModel<Vector2>()
      {
        Name = name,
        Editor = editor,
        MaxConnections = 0
      };
      result.Port.IsVisible = false;
      return result;
    }

    public static ValueNodeInputViewModel<object> CreateEnumEditor(string name, Type type)
    {
      var result = new ValueNodeInputViewModel<object>()
      {
        Name = name,
        Editor = new EnumEditorViewModel(type),
        MaxConnections = 0
      };
      result.Port.IsVisible = false;
      return result;
    }

    public static ValueNodeInputViewModel<IModule> CreateNodeInput(string name)
    {
      return new ValueNodeInputViewModel<IModule>()
      {
        Name = name
      };
    }


  }
}
