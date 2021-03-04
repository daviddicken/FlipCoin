using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlipCoin
{
  public partial class MainPage : ContentPage
  {
    bool clicked = true;
    public MainPage()
    {
      InitializeComponent();
    }

    void OnButtonClicked(Object sender, EventArgs e)
    {
      
      if (clicked == true)
      {
        clicked = false;
      }
      else
      {
        clicked = true;
      }

      if (clicked == false)
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
