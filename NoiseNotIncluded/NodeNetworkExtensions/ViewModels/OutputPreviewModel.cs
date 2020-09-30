using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetworkExtensions.Views;
using ReactiveUI;

namespace NodeNetworkExtensions.ViewModels
{
  public class OutputPreviewModel : ValueNodeOutputViewModel<IModule>
  {
    static OutputPreviewModel()
    {
      Splat.Locator.CurrentMutable.Register(() => new OutputPreviewView(), typeof(IViewFor<OutputPreviewModel>));
    }
  }
}
