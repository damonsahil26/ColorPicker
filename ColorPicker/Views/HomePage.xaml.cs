
using CommunityToolkit.Maui.Alerts;

namespace ColorPicker.Views;

public partial class HomePage : ContentPage
{
    bool _isRandomClicked;
    string _hexValue = string.Empty;
    public HomePage()
    {
        InitializeComponent();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!_isRandomClicked)
        {
            var redColor = sliderRed.Value;
            var greenColor = sliderGreen.Value;
            var blueColor = sliderBlue.Value;

            var color = Color.FromRgb(redColor, greenColor, blueColor);

            SetColor(color);
        }
    }

    private void SetColor(Color color)
    {
        app_container.BackgroundColor = color;
        button_RandomColor.BackgroundColor = color;
        _hexValue = color.ToHex();
        HexCode.Text = $"Hex Code: {color.ToHex()}";
    }

    private void button_RandomColor_Clicked(object sender, EventArgs e)
    {
        _isRandomClicked = true;
        var random = new Random();

        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        SetColor(color);

        sliderRed.Value = color.Red;
        sliderGreen.Value = color.Green;
        sliderBlue.Value = color.Blue;
        _isRandomClicked = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(_hexValue);
        var toast = Toast.Make($"Code Copied to Clipboard"
            , CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}