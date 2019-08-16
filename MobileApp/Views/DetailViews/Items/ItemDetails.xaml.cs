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

namespace MobileApp.Views.DetailViews.Items
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetails : ContentPage
    {
        public ItemDetails(String id)
        {
            InitializeComponent();
            Init(id);
        }

        async void Init(string id)
        {
            await getDetails(id);
        }

        async Task getDetails(string id)
        {
            var client = new RestClient(Constant.apiItems + id);
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteGetTaskAsync<JObject>(request);
            var item = JObject.Parse(response.Content);

            lbl_Name.Text = item["ShortDescription"].ToString();
            try
            {
                lbl_Price.Text = item["LastCost1"].ToString();
            }
            catch
            {
                lbl_Price.Text = "No data";
            }

            lbl_Description.Text = item["Description1"].ToString();
            lbl_Type.Text = item["Type"].ToString();
        }
    }
}