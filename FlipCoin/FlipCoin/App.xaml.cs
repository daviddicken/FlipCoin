using FlipCoin.ViewModels;
using FlipCoin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlipCoin
{
  public partial class App : Application
  {
    readonly MainView _vm;
    public App()
    {
      InitializeComponent();
      BindingContext = _vm = new MainView();
      
      MainPage = new NavigationPage(new MainPage());    
    }

    protected override void OnStart()
    {
      _vm.TurnOnAccelerometer();
    }

    protected override void OnSleep()
    {
      _vm.TurnOffAccelerometer();
    }

    protected override void OnResume()
    {
      _vm.TurnOnAccelerometer();
    }
  }
}
