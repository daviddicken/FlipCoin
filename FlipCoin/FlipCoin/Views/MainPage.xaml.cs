using FlipCoin.ViewModels;
using FlipCoin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlipCoin 
{
  //public event PropertyChangedEventHandler PropertyChanged;
  public partial class MainPage : ContentPage
  {
    readonly MainView _vm;
    int Flips { get; set; }

    public MainPage()
    {
      InitializeComponent();
      // Allows access to methods and properties in the MainView
      BindingContext = _vm = new MainView();
    }

    protected override void OnAppearing()
    {
      _vm.Path = "SamuelHead.jpg";
    }

    void OnButtonClicked(Object sender, EventArgs e)
    {      
      _vm.ChangePic();
    } 
    
    private async void GoToEenieMeenie(Object sender, EventArgs e)
    {
      await Navigation.PushAsync(new EenieMeenie());
    }
  }  
}

