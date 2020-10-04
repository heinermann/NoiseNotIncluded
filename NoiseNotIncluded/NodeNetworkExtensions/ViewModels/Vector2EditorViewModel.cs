using NodeNetwork.Toolkit.ValueNode;
using NodeNetworkExtensions.Views;
using ReactiveUI;
using System.Numerics;

namespace NodeNetworkExtensions.ViewModels
{
  public class Vector2EditorViewModel : ValueEditorViewModel<Vector2>
  {
    static Vector2EditorViewModel()
    {
      Splat.Locator.CurrentMutable.Register(() => new Vector2EditorView(), typeof(IViewFor<Vector2EditorViewModel>));
    }

    public Vector2EditorViewModel()
    {
      Value = new Vector2();
    }
  }
}
