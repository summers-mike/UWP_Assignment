using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Glazer_Calculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
        }

        const double MAX_WIDTH = 5.0;
        const double MIN_WIDTH = 0.5;
        const double MAX_HEIGHT = 3.0;
        const double MIN_HEIGHT = 0.75;
        double width;
        double height;
        double woodLength;
        double glassArea;
        double totalWoodLength;
        double totalGlassArea;
        double quantity = 1;
        string tint = "Black";
        string Today = DateTime.Now.ToString("MM/dd/yyyy");
        bool noWidthErrors = false;
        bool noHeightErrors = false;


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream =
                await synth.SynthesizeTextToStreamAsync("Hello, World!");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private async void quantitySlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            
        }


        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((noWidthErrors == true) && (noHeightErrors == true) && (widthInput.Text != "") && (heightInput.Text != ""))
            {
                width = double.Parse(widthInput.Text);
                height = double.Parse(heightInput.Text);
                woodLength = 2 * (width + height) * 3.25;
                glassArea = 2 * (width * height);
                quantity = quantitySlider.Value;
                totalWoodLength = quantity * woodLength;
                totalGlassArea = quantity * glassArea;
                //tint = tintSelect.SelectedValue.ToString();

                myErrors.Text = "";
                myOutput.Text = "Date: " + Today + "\n" +
                            "Entered Width: " + width + "\n" +
                            "Entered Height: " + height + "\n" +
                            "Entered Quantity: " + quantity + "\n" +
                            "Selected Tint: " + tint + "\n" +
                            "Wood Length Needed: " + totalWoodLength + " feet\n" +
                            "Glass Surface Needed: " + totalGlassArea + " sq metres\n";
            }
            else
            {
                myErrors.Text = "You need to fill out the form completely and check inputs";
            }
        }

        private void widthInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            noWidthErrors = false;
            myErrors.Text = "";
            double widthValue;
            if (widthInput.Text == "")
            {
                myErrors.Text = "Please Enter a Width";
                noWidthErrors = false;
            }
            else if (Double.TryParse(widthInput.Text, out widthValue) == true)
            {
                if ((widthInput.Text != "") &&
                     ((double.Parse(widthInput.Text) < MIN_WIDTH) || (double.Parse(widthInput.Text) > MAX_WIDTH)))
                {
                    myErrors.Text = "Please Enter a Valid Width";
                    noWidthErrors = false;
                }
                else
                {
                    myErrors.Text = "";
                    noWidthErrors = true;
                }
            }
            else if (Double.TryParse(widthInput.Text, out widthValue) == false)
            {
                myErrors.Text = "This is Not a Valid Entry for Width";
                noWidthErrors = false;
            }
            else
            {
                myErrors.Text = "";
                noWidthErrors = true;
            }
        }

        private void heightInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            noHeightErrors = false;
            myErrors.Text = "";
            double heightValue;
            if (heightInput.Text == "")
            {
                myErrors.Text = "Please Enter a Height";
                noHeightErrors = false;
            }
            else if (Double.TryParse(heightInput.Text, out heightValue) == true)
            {
                if ((heightInput.Text != "") &&
                     ((double.Parse(heightInput.Text) < MIN_HEIGHT) || (double.Parse(heightInput.Text) > MAX_HEIGHT)))
                {
                    myErrors.Text = "Please Enter a Valid Height";
                    noHeightErrors = false;
                }
                else
                {
                    myErrors.Text = "";
                    noHeightErrors = true;
                }
            }
            else if (Double.TryParse(heightInput.Text, out heightValue) == false)
            {
                myErrors.Text = "This is Not a Valid Entry for Height";
                noHeightErrors = false;
            }
            else
            {
                myErrors.Text = "";
                noHeightErrors = true;
            }
        }

        private void Black_Checked(object sender, RoutedEventArgs e)
        {
            tint = "Black";
        }

        private void Blue_Checked(object sender, RoutedEventArgs e)
        {
            tint = "Blue";
        }

        private void Brown_Checked(object sender, RoutedEventArgs e)
        {
            tint = "Brown";
        }
    }
}
