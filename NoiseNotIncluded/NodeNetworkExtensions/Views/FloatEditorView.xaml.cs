using System.Reactive.Disposables;
using System.Windows;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class FloatEditorView : IViewFor<FloatEditorViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(FloatEditorViewModel), typeof(FloatEditorView), new PropertyMetadata(null));

    public FloatEditorViewModel ViewModel
    {
      get => (FloatEditorViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (FloatEditorViewModel)value;
    }
    #endregion

    public FloatEditorView()
    {
      InitializeComponent();

      this.WhenActivated(d => {
        this.Bind(ViewModel, vm => vm.Value, v => v.UpDown.Value).DisposeWith(d);
      });
    }
  }
}
