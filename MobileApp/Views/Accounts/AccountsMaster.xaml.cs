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
using MobileApp.Views.DetailViews.Accounts;

namespace MobileApp.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountsMaster : ContentPage
    {
        List<Tuple<string, int?>> Items;
        public AccountsMaster()
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
            Items = new List<Tuple<string, int?>>();
            var client = new RestClient(Constant.apiAccounts);
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteGetTaskAsync<JArray>(request);
            var salesPersons = JArray.Parse(response.Content);

            foreach (var persone in salesPersons[0]["accounts"])
            {
                Items.Add(new Tuple<string,int?>(persone.Value<String>("acc_chart_name1"), persone.Value<int?>("FK_acc_chart_add_id")));
            }

             AccountsPersonsList.ItemsSource = Items;
            ActivitySpinner.IsVisible = false;
        }

        async void GetDetails(object sender, SelectedItemChangedEventArgs e)
        {
            Tuple<string, int?> item = (Tuple<string,int?>)e.SelectedItem;
            // TODO: open detail page
            // SetPage( page )
            Application.Current.MainPage = new NavigationPage(new AccountDetails(item.Item1, item.Item2));
            
        }
    }
}