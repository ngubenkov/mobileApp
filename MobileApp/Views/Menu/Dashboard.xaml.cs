using MobileApp.Models;
using MobileApp.Views.Menu.DetailViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constant.BackgroundColor;
            App.StartCheckIfInternet(lbl_NoInternet, this);
        }

        async void SeelectedScreen1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }
    }
}