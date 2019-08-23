using MobileApp.Models;
using MobileApp.Views.DetailViews;
using MobileApp.Views.DetailViews.Items;
using MobileApp.Views.DetailViews.SettingsViews;
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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("InfoScreen1", "LoginIcon.png", Color.White, typeof(InfoScreen1)));
            items.Add(new MasterMenuItem("Accounts", "LoginIcon.png", Color.White, typeof(AccountsMaster)));
            items.Add(new MasterMenuItem("Sales Persons", "LoginIcon.png", Color.White, typeof(SalesPersons)));
            items.Add(new MasterMenuItem("Items", "LoginIcon.png", Color.White, typeof(ItemsMaster)));
            items.Add(new MasterMenuItem("Items v2", "LoginIcon.png", Color.White, typeof(ItemsMasterList)));
            items.Add(new MasterMenuItem("Setting", "LoginIcon.png", Color.White, typeof(SettingsScreen)));
      

            ListView.ItemsSource = items;

        }

        async void Logout(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
            }
        }
    }
}