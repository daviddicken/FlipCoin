using FlipCoin.ViewModels;
using FlipCoin.Views;
using System;
using Xamarin.Essentials;
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
      SensorSpeed speed = SensorSpeed.UI;
      _vm.TurnOnAccelerometer(speed);
    }

    protected override void OnSleep()
    {
      _vm.TurnOffAccelerometer();
    }

    protected override void OnResume()
    {
      SensorSpeed speed = SensorSpeed.UI;
      _vm.TurnOnAccelerometer(speed);
    }
  }
}
