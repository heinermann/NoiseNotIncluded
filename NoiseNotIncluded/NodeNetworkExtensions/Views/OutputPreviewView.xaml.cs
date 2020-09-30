using System;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LibNoise;
using NodeNetworkExtensions.ViewModels;
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
    readonly float[] pixelValues = new float[IMG_WIDTH * IMG_HEIGHT];

    public void UpdatePreview(IModule module)
    {
      if (module == null)
      {
        pixels.Initialize();
      }
      else
      {
        // First loop, obtain the values and determine min/max
        float min = float.MaxValue, max = float.MinValue;
        for (int y = 0; y < IMG_HEIGHT; ++y)
        {
          for (int x = 0; x < IMG_WIDTH; ++x)
          {
            float pixelValue = (module as IModule3D).GetValue(x, 0, y);
            pixelValues[x + y * IMG_WIDTH] = pixelValue;

            if (pixelValue < min) min = pixelValue;
            if (pixelValue > max) max = pixelValue;
          }
        }

        // Second loop, write pixel info based on the min/max
        float range = max - min;
        for (int y = 0; y < IMG_HEIGHT; ++y)
        {
          for (int x = 0; x < IMG_WIDTH; ++x)
          {

            byte pixelValue = (byte)Math.Floor((pixelValues[x + y * IMG_WIDTH] - min) / range * 255);
            pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP] = pixelValue;
            pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 1] = pixelValue;
            pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 2] = pixelValue;
            pixels[x * IMG_BPP + y * IMG_WIDTH * IMG_BPP + 3] = 0xFF;
          }
        }
      }

      previewImg.WritePixels(imgRect, pixels, IMG_STRIDE, 0);
    }

    public OutputPreviewView()
    {
      pixels.Initialize();
      InitializeComponent();

      Preview.Source = previewImg;

      this.WhenActivated(d => {
        ViewModel.Value.Subscribe(UpdatePreview).DisposeWith(d);
      });
    }
  }
}
