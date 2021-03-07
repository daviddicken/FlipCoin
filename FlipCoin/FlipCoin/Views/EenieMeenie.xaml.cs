using FlipCoin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlipCoin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EenieMeenie : ContentPage
    {
        readonly EenieViewModel _vm;

        public EenieMeenie()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            
        }
    private async void GoToMainPage(Object sender, EventArgs e)
    {
      await Navigation.PushAsync(new MainPage());
    }
  }
}