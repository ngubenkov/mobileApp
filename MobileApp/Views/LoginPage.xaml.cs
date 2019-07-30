using MobileApp.Models;
using MobileApp.Views.Menu;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constant.BackgroundColor;
            Lbl_Password.TextColor = Constant.MaintTextColor;
            Lbl_Username.TextColor = Constant.MaintTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constant.LoginIconHeight;
            App.StartCheckIfInternet(lbl_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Username.Completed += (s, e) => SignInProcedure(s, e);

        }

        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login success", "Oke");
                // var result = await App.RestService.Login(user);  // used for testing purpose
                var result = new Token();
                if(result != null)
                {
                //    App.UserDatabase.SaveUser(user);
                //    App.TokenDatabase.SaveToken(result);
                //    await Navigation.PushAsync(new Dashboard());
                    if(Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                    }
                }
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct", "Oke");
            }
        }
    }
}