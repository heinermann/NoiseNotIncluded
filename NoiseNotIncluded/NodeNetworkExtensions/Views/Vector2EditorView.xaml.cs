using System.Numerics;
using System.Reactive.Disposables;
using System.Windows;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class Vector2EditorView : IViewFor<Vector2EditorViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(Vector2EditorViewModel), typeof(Vector2EditorView), new PropertyMetadata(null));

    public Vector2EditorViewModel ViewModel
    {
      get => (Vector2EditorViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (Vector2EditorViewModel)value;
    }
    #endregion

    public Vector2EditorView()
    {
      InitializeComponent();

      this.WhenActivated(d => {
        this.Bind(ViewModel, vm => vm.Value.X, v => v.X.Value).DisposeWith(d);
        this.Bind(ViewModel, vm => vm.Value.Y, v => v.Y.Value).DisposeWith(d);
      });
    }

    private void X_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      if (ViewModel?.Value == null) return;

      Vector2 vec = ViewModel.Value;
      vec.X = X.Value.GetValueOrDefault();
      ViewModel.Value = vec;
    }

    private void Y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      if (ViewModel?.Value == null) return;

      Vector2 vec = ViewModel.Value;
      vec.Y = Y.Value.GetValueOrDefault();
      ViewModel.Value = vec;
    }
  }
}
