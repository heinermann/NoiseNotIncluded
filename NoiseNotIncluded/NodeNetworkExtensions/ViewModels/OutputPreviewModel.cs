using LibNoise;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetworkExtensions.Views;
using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace NodeNetworkExtensions.ViewModels
{
  public class OutputPreviewModel : ValueEditorViewModel<IModule>
  {
    public IObservable<float> ZoomChanged { get; }

    #region Zoom
    private float _zoom = 0.1f;
    public float Zoom
    {
      get => _zoom;
      set => this.RaiseAndSetIfChanged(ref _zoom, value);
    }
    #endregion

    static OutputPreviewModel()
    {
      Splat.Locator.CurrentMutable.Register(() => new OutputPreviewView(), typeof(IViewFor<OutputPreviewModel>));
    }

    public OutputPreviewModel()
    {
      Value = null;
      ZoomChanged = this.WhenAnyValue(c => c.Zoom);
    }


  }
}
