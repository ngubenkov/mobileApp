using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Models
{
    public class Constant
    {
        public static bool isDev = true;

        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MaintTextColor = Color.White;

        public static int LoginIconHeight = 120;


        // -----------Login-------
        public static string LoginUrl = "https://test.com/api/Auth/Login";
        public static string NoInternetText = "No internet, please connect";

        public static string SettingScreenTitle = "Settings";

        // ------------API endpoints--------------
        public static string apiSalesPersons = "http://192.168.201.25:8000/api/salespersons/";
        public static string apiAccounts = "http://192.168.201.25:8000/api/accounts/";
    }
}
