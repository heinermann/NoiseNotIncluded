using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LibNoise;
using LibNoise.Builder;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Util;
using ReactiveUI;

namespace NodeNetworkExtensions.Views
{
  public partial class OutputPreviewView : IViewFor<OutputPreviewModel>
  {
    const int IMG_WIDTH = 128;
    const int IMG_HEIGHT = 128;
    const int IMG_BPP = 4;
    const int IMG_STRIDE = IMG_WIDTH * IMG_BPP;

    #region ViewModel
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
        typeof(OutputPreviewModel), typeof(OutputPreviewView), new PropertyMetadata(null));

    public OutputPreviewModel ViewModel
    {
      get => (OutputPreviewModel)GetValue(ViewModelProperty);
      set => SetValue(ViewModelProperty, value);
    }

    object IViewFor.ViewModel
    {
      get => ViewModel;
      set => ViewModel = (OutputPreviewModel)value;
    }
    #endregion

    // 96 dpi is "100%"
    Int32Rect imgRect = new Int32Rect(0, 0, IMG_WIDTH, IMG_HEIGHT);
    WriteableBitmap previewImg = new WriteableBitmap(IMG_WIDTH, IMG_HEIGHT, 96, 96, PixelFormats.Bgr32, null);
    readonly byte[] pixels = new byte[IMG_WIDTH * IMG_HEIGHT * IMG_BPP];
    NoiseMapBuilderPlane builderPlane = null;

    public void UpdatePreview(IModule module)
    {
      if (module == null || LibNoiseHelpers.HasLoop(module))
      {
        Preview.Visibility = Visibility.Collapsed;
        return;
      }

      builderPlane = new NoiseMapBuilderPlane(0f, IMG_WIDTH * ViewModel.Zoom, 0f, IMG_HEIGHT * ViewModel.Zoom, false);

      builderPlane.SetSize(IMG_WIDTH, IMG_HEIGHT);
      builderPlane.SourceModule = module;
      builderPlane.NoiseMap = new NoiseMap(IMG_WIDTH, IMG_HEIGHT);

      builderPlane.Build();

      // Determine min/max
      float min = float.MaxValue, max = float.MinValue;
      builderPlane.NoiseMap.MinMax(out min, out max);

      // Write pixel info based on the min/max
      float range = max - min;
      for (int y = 0; y < IMG_HEIGHT; ++y)
      {
        for (int x = 0; x < IMG_WIDTH; ++x)
        {
          byte pixelValue = (byte)Math.Floor((builderPlane.NoiseMap.GetValue(x, y) - min) / range * 255);
          pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP] = pixelValue;
          pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 1] = pixelValue;
          pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 2] = pixelValue;
          pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 3] = 0xFF;
        }
      }

      previewImg.WritePixels(imgRect, pixels, IMG_STRIDE, 0);

      Preview.Visibility = Visibility.Visible;
    }

    public OutputPreviewView()
    {
      pixels.Initialize();
      InitializeComponent();

      Preview.Source = previewImg;

      this.WhenActivated(d => {
        ViewModel.ValueChanged.Subscribe(UpdatePreview).DisposeWith(d);
        ViewModel.ZoomChanged.Subscribe(_ => UpdatePreview(ViewModel.Value)).DisposeWith(d);
      });
    }

    private void Preview_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
      Point pos = e.GetPosition(Preview);
      int px = (int)Math.Floor(pos.X * Preview.Source.Width / Preview.ActualWidth);
      int py = (int)Math.Floor(pos.Y * Preview.Source.Height / Preview.ActualHeight);

      if (px < 0) px = 0;
      if (py < 0) py = 0;
      if (px >= IMG_WIDTH) px = IMG_WIDTH - 1;
      if (py >= IMG_HEIGHT) py = IMG_HEIGHT - 1;

      float value = builderPlane.NoiseMap.GetValue(px, py);

      TooltipContent.Text = $"{value}";
      FloatingTooltip.IsOpen = true;
      FloatingTooltip.HorizontalOffset = pos.X + 20;
      FloatingTooltip.VerticalOffset = pos.Y;
    }

    private void Preview_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
      FloatingTooltip.IsOpen = false;
    }
  }
}
