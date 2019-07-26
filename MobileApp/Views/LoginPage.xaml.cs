using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        void Init()
        {
            BackgroundColor = Constant.BackgroundColor;
            Lbl_Password.TextColor = Constant.MaintTextColor; 
            Lbl_Username.TextColor = Constant.MaintTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constant.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Username.Completed += (s, e) => SignInProcedure(s,e);
        }
        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login success", "Oke");
            }
            else
            {
                DisplayAlert("Login", "Login Not Correct", "Oke");
            }
        }
    }
}