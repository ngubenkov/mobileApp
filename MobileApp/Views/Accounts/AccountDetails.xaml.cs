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
    public partial class AccountDetails : ContentPage
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
            lbl_test.Text = String.Format(Constant.apiAccountDetail + Constant.id.ToString() + id.ToString() + "/" );
            
            var client = new RestClient(Constant.apiAccountDetail + id.ToString() + "/" );
            var request = new RestRequest(Method.GET);
            // TODO: API IS FUCKED WITH ID alwasys returns no data
            try
            {
                var response = await client.ExecuteGetTaskAsync<JObject>(request);
                var accountDetails = JObject.Parse(response.Content);
                lbl_Address.Text = accountDetails["address"][0]["City"].ToString();
                lbl_PhoneNumber.Text = accountDetails["phones"][0]["phone"].ToString();
                lbl_Email.Text = accountDetails["emails"][0]["email"].ToString();
            }
            catch
            {
                lbl_Address.Text = "No data";
                lbl_PhoneNumber.Text = "No data";
                lbl_Email.Text = "No data";
            }
            
            btn_GoBack.Clicked += (s, e) => goBackToMaster(s, e);
        }

        async void goBackToMaster(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new AccountsMaster());
        }
    }
}