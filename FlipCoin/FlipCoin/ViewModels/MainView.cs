using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlipCoin.ViewModels
{
  class MainView : BaseViewModel
  {
    //public event PropertyChangedEventHandler PropertyChanged;

    private float x;
    private float y;
    private float z;
    private string path;

    public string Path
    {
      get => path;
      set => SetProperty(ref path, value);
    }

    public float X
    {
      get => x;
      set => SetProperty(ref x, value);
    }

    public float Y
    {
      get => y;
      set => SetProperty(ref y, value);
    }

    public float Z
    {
      get => z;
      set => SetProperty(ref z, value);
    }

    //================== Accelerometer =================
    SensorSpeed speed = SensorSpeed.UI;

    public MainView()
    {
      Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
    }


    void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
      var data = e.Reading;
      X = data.Acceleration.X;
      Y = data.Acceleration.Y;
      if (Y > .5) ChangePic();
      Z = data.Acceleration.Z;
    }

    public void TurnOnAccelerometer(SensorSpeed speed)
    {
      try
      {
        if (!Accelerometer.IsMonitoring)
          Accelerometer.Start(speed);
      }
      catch (FeatureNotEnabledException fnsEx)
      {
        Console.WriteLine("Device does not support Accelerometers");
      }
      catch (Exception e)
      {
        Console.WriteLine("Something went wrong");
      }
    }

    public void TurnOffAccelerometer()
    {
      if (Accelerometer.IsMonitoring)
        Accelerometer.Stop();
    }

   //============ Coin flip =================

   
    public void ChangePic()
    {
      TurnOffAccelerometer();
      Random rand = new Random();
      int numOfFlips = rand.Next(10, 30);
      int flipCounter = 0;
      // Modified Alan's timer for this feature
      Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
      {
        flipCounter++;
        if (flipCounter <= numOfFlips)
        {
          Device.BeginInvokeOnMainThread(() => CyclePics(flipCounter));
          return true;
        }
        TurnOnAccelerometer(speed);
        return false;
      });
      
    }

    public void CyclePics(int i)
    {      
      if (i % 2 == 0) Path = "tails1.png";
      else Path = "SamuelHead.jpg";
    }

  }
}

