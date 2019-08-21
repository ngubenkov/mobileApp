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
        Product item;
        Models.Cart chart;
        public ItemDetails(String id, Models.Cart chart)
        {
            this.chart = chart;
            InitializeComponent();
            _ = Init(id);

        }

        async Task Init(string id)
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
            finally
            {
                lbl_Description.Text = item["Description1"].ToString();
                lbl_Type.Text = item["Type"].ToString();
                this.item = new Product(Convert.ToInt32(item["ID"]),
                    Convert.ToInt32(item["CompanyID"]), item["ShortDescription"].ToString(), (double?)item["LastCost1"]);
            }
        }

        void addItemToChart(object sender, EventArgs e)
        {
            this.chart.addItemToCart(this.item, 1);
        }

        void goToChart(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Views.Cart.Cart(this.chart));
        }
    }


}
