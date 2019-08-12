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

        // ------------Encryption-------------------
        public static string Key = "e2uSo0f1t4ro";
        
        // -----------Login-------
        public static string LoginUrl = "https://test.com/api/Auth/Login";
        public static string NoInternetText = "No internet, please connect";

        public static string SettingScreenTitle = "Settings";

        // ------------API endpoints--------------
        //    public static string endPoint = "http://192.168.137.1:8000/api/";  // change this var during testing coffee house
        public static string endPoint = "http://192.168.137.1:8000/api/"; // home wifi
        public static string apiSalesPersons = endPoint+"salespersons/";
        public static string apiAccounts = endPoint + "accounts/";
        public static string apiAuth = endPoint + "auth/";
        public static string apiAccountDetail = endPoint + "account/details/";
    }
}
