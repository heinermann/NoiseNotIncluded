using System.Reactive.Disposables;
using System.Windows;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class IntegerEditorView : IViewFor<IntegerEditorViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(IntegerEditorViewModel), typeof(IntegerEditorView), new PropertyMetadata(null));

    public IntegerEditorViewModel ViewModel
    {
      get => (IntegerEditorViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (IntegerEditorViewModel)value;
    }
    #endregion

    public IntegerEditorView()
    {
      InitializeComponent();

      this.WhenActivated(d => {
        this.Bind(ViewModel, vm => vm.Value, v => v.UpDown.Value).DisposeWith(d);
      });
    }
  }
}
