using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;

namespace FlipCoin.ViewModels
{
  class EenieViewModel : MainView 
  {
    private string photo;
    private string winner;
    private string text;
    private bool running = false;

    public string Winner
    {
      get => winner;
      set => SetProperty(ref winner, value);
    }

    public string Text 
    {
      get => text;
      set => SetProperty(ref text, value);
    }

    public string Photo
    {
      get => photo;
      set => SetProperty(ref photo, value);
    }

    SensorSpeed speed = SensorSpeed.Game;
    public EenieViewModel()
    {
      Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
    }

    void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
      if (!running)
      {
        running = true;
        TurnOffAccelerometer();
        EenieMeenieMineyMo();
      }
      running = false;
    }
    
    public void EenieMeenieMineyMo()

    {
      winner = "";
      OnPropertyChanged(nameof(Winner));
      string sentence = "Eenie Meenie Miney Moe Catch A Tiger By His Toe If He Hollers Let Him Go, My Mom Said That You Are The One!!!";
      
      string[] strArr = sentence.Split(' ');
      Queue<string> photos = new Queue<string>();
      photos.Enqueue("SamuelHead.jpg");
      photos.Enqueue("tails1.png");
      photos.Enqueue("tails3.png");

      Random rand = new Random();
      int num = rand.Next(1,100);

      RandomStart(photos, num);

      int index = -1;
      Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
      {
        index++;
        if(index < strArr.Length)
        {
          Device.BeginInvokeOnMainThread(() => PrintWord(strArr[index], photos));          
          return true;
        }

        if(photo != "")
        {
          int dot = photo.LastIndexOf('.');
          winner = photo.Substring(0, dot);
          OnPropertyChanged(nameof(Winner));
        }
        
        return false;
      });

      TurnOnAccelerometer(speed);
      Thread.Sleep(2000);
    }

    public void PrintWord(string word, Queue<string> q)
    {
      photo = q.Dequeue();
      q.Enqueue(photo);
      text = word;
      OnPropertyChanged(nameof(Text));
      OnPropertyChanged(nameof(Photo));
    }

    public void RandomStart(Queue<string> q, int num)
    {
      for(int i = 0; i < num; i++)
      {
        q.Enqueue(q.Dequeue());
      }
    }
  }
}
