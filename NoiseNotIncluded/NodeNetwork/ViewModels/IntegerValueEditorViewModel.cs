using NodeNetworkExtensions.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace NodeNetworkExtensions.ViewModels
{
  public class IntegerValueEditorViewModel : ValueEditorViewModel<int?>
  {
    static IntegerValueEditorViewModel()
    {
      Splat.Locator.CurrentMutable.Register(() => new IntegerValueEditorView(), typeof(IViewFor<IntegerValueEditorViewModel>));
    }

    public IntegerValueEditorViewModel()
    {
      Value = 0;
    }
  }
}