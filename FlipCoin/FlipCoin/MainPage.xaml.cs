using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlipCoin
{
  //public event PropertyChangedEventHandler PropertyChanged;
  public partial class MainPage : ContentPage
  {
    int Flips { get; set; }

    //bool clicked = true;
    public MainPage()
    {
      InitializeComponent();
    }

   
    void OnButtonClicked(Object sender, EventArgs e)
    {
      Random rand = new Random();
      int flips = rand.Next(10, 30);
      Flips = 0;
      // Modified Alan's timer for this feature
      Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
      {
        Flips++;
        if(Flips < flips)
        {
          Device.BeginInvokeOnMainThread(() => RandomNum());
          return true;
        }       
        return false;
      });    
  }
  
    public void RandomNum()
    {
      Random rand = new Random();
      int flips = rand.Next(100, 300);

      if (Heads.IsVisible)
      {
        Tails.IsVisible = true;
        Heads.IsVisible = false;
      }
      else
      {
        Tails.IsVisible = false;
        Heads.IsVisible = true;
      }
      
    }
      
  }
}

