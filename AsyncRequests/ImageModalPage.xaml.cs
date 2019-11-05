using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AsyncRequests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageModalPage : ContentPage
    {
        public ImageModalPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
