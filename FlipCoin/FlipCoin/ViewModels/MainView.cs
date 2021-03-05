using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlipCoin.ViewModels
{
  class MainView : BaseViewModel
  {
    private float x;
    private float y;
    private float z;
    private int Flips;

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
      Z = data.Acceleration.Z;

      

    }

    //public void Flip()
    //{
    //  if (Y > 0.5)
    //  {
    //    Random rand = new Random();
    //    int flips = rand.Next(10, 30);
    //    Flips = 0;
    //    // Modified Alan's timer for this feature
    //    Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
    //    {
    //      Flips++;
    //      if (Flips < flips)
    //      {
    //        Device.BeginInvokeOnMainThread(() => RandomNum());
    //        return true;
    //      }
    //      return false;
    //    });
    //  }
    //}

    //public void RandomNum()
    //{
    //  Random rand = new Random();
    //  int flips = rand.Next(100, 300);

    //  if (Heads.IsVisible)
    //  {
    //    Tails.IsVisible = true;
    //    Heads.IsVisible = false;
    //  }
    //  else
    //  {
    //    Tails.IsVisible = false;
    //    Heads.IsVisible = true;
    //  }

    //}

    public void ToggleAccelerometer()
    {
      try
      {
        if (Accelerometer.IsMonitoring)
          Accelerometer.Stop();
        else
          Accelerometer.Start(speed);
          
          

      }
      catch(FeatureNotEnabledException fnsEx)
      {
        Console.WriteLine("Device does not support Accelerometers");
      }
      catch(Exception e)
      {
        Console.WriteLine("Something went wrong");
      }
    }


  }
}
