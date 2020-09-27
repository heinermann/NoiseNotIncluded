using System.Reactive.Disposables;
using System.Windows;
using NodeNetworkExtensions.ViewModels;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class EnumEditorView : IViewFor<EnumEditorViewModel>
  {
    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(EnumEditorViewModel), typeof(EnumEditorView), new PropertyMetadata(null));

    public EnumEditorViewModel ViewModel
    {
      get => (EnumEditorViewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (EnumEditorViewModel)value;
    }
    #endregion

    public EnumEditorView()
    {
      InitializeComponent();

      this.WhenActivated(d =>
      {
        this.OneWayBind(ViewModel, vm => vm.OptionLabels, v => v.valueComboBox.ItemsSource).DisposeWith(d);
        this.Bind(ViewModel, vm => vm.SelectedOptionIndex, v => v.valueComboBox.SelectedIndex).DisposeWith(d);
      });
    }
  }
}