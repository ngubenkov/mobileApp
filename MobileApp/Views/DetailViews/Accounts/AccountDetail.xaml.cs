using MobileApp.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.DetailViews.Accounts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountDetails : ContentView
    {
        public string AccountName;
        public int? id;
        public AccountDetails(string AccountName, int? id)
        {
            InitializeComponent();
            this.AccountName = AccountName;
            this.id = id;
            Init();
        }

        async void Init()
        {
            lbl_AccountName.Text = AccountName;
            var client = new RestClient(String.Format(Constant.apiAccountDetail,id.ToString()));
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteGetTaskAsync<JArray>(request);
            var accountDetails = JArray.Parse(response.Content);
            lbl_Address.Text = accountDetails["address"][0]["City"].ToString();
            lbl_PhoneNumber.Text = accountDetails["phones"][0]["phone"].ToString();
            lbl_email.Text = accountDetails["emails"][0]["email"].ToString();
        }
    }
}