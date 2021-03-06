using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlipCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EenieMeenie : ContentPage
    {
        public EenieMeenie()
        {
            InitializeComponent();
        }

        private async void GoToMainPage(Object sender, EventArgs e)
        {
          await Navigation.PushAsync(new MainPage());
        }
    //protected virtual bool OnBackButtonPressed()
    //{

    //}
  }
}