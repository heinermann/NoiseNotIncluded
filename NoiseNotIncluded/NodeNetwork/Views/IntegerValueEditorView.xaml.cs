using System.Reactive.Disposables;
using System.Windows;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class IntegerValueEditorView : IViewFor<IntegerValueEditorViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(IntegerValueEditorViewModel), typeof(IntegerValueEditorView), new PropertyMetadata(null));

    public IntegerValueEditorViewModel ViewModel
    {
      get => (IntegerValueEditorViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (IntegerValueEditorViewModel)value;
    }
    #endregion

    public IntegerValueEditorView()
    {
      InitializeComponent();

      this.WhenActivated(d => {
        this.Bind(ViewModel, vm => vm.Value, v => v.UpDown.Value).DisposeWith(d);
      });
    }
  }
}
