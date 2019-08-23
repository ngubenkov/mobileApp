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
    public partial class SalesPersons : ContentPage
    {

        List<String> Items;
        public SalesPersons()
        {
            InitializeComponent();

            InitList();
        }
        void InitList()
        {
            Items = new List<string>();
            var client = new RestClient(Constant.apiSalesPersons);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var salesPersons = JArray.Parse(response.Content);
            foreach( var persone in salesPersons[0]["SalesPersons"])
            {
                Items.Add(persone.Value<String>("Name"));
            }
            
            SalesPersonsList.ItemsSource = Items;
        }
    }
}