using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using RestSharp;
using MobileApp.Models;
using Newtonsoft.Json.Linq;
namespace MobileApp.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accounts : ContentPage
    {
        List<String> Items;
        public Accounts()
        {
            InitializeComponent();
            Init();
            InitList();
        }

        void Init()
        {
            ActivitySpinner.IsVisible = true;
        }
         async void InitList()
        {
            Items = new List<string>();
            var client = new RestClient(Constant.apiAccounts);
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteGetTaskAsync<JArray>(request);
            var salesPersons = JArray.Parse(response.Content);

            foreach (var persone in salesPersons[0]["accounts"])
            {
                Items.Add(persone.Value<String>("acc_chart_name1"));
            }

             AccountsPersonsList.ItemsSource = Items;
            ActivitySpinner.IsVisible = false;
        }
    }
}