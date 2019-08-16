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
    public partial class ItemsMasterList : ContentPage
    {
        private List<Product> productArrayList;
        private int rows;
        private int col;

        public ItemsMasterList()
        {
            InitializeComponent();
            Init();
        }

        async void Init()
        {
            productArrayList = await GetListOfProducts();

            var productIndex = 0;
            for (int rowIndex = 0; rowIndex < this.rows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.col; columnIndex++)
                {
                    if (productIndex >= productArrayList.Count)
                    {
                        break;
                    }
                    Product product = productArrayList[productIndex];
                    productIndex += 1;

                    StackLayout item = createItem(product);

                    gridLayout.Children.Add(item, columnIndex, rowIndex);

                }
            }
            ActivitySpinner.IsVisible = false;
        }

        async Task<List<Product>> GetListOfProducts()
        {
            List<Product> productsList = new List<Product>();
            var client = new RestClient(Constant.apiItems);
            var request = new RestRequest(Method.GET);

            var response = await client.ExecuteGetTaskAsync<JObject>(request);
            var items = JObject.Parse(response.Content);
            foreach (JObject item in items["items"])
            {
                productsList.Add(item.ToObject<Product>());
            }

            createGrid((int)(Convert.ToInt32(items["rows"]) / 3), 3);

            return productsList;
        }

        void createGrid(int rows, int cols) // create empty grid
        {
            // TODO: add row/col defenition with some parameters to make screen scrollabpe
            this.rows = rows;
            this.col = cols;

            for (int i = 0; i < rows; i++)
            {
                gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            }
            for (int i = 0; i < cols; i++)
            {
                gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });
            }
        }

        StackLayout createItem(Product product)
        // describe cell in items grid
        {
            Label label = new Label
            {
                Text = product.description,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            ImageButton image = new ImageButton
            {
                Source = "LoginIcon.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                HeightRequest = 100,
                AutomationId = Convert.ToString(product.id)

            };
            // TODO: find a way to assign function on click at specific cell
            image.Clicked += OnImageButtonClicked;
            
            StackLayout stack = new StackLayout();
            stack.Children.Add(image);
            stack.Children.Add(label);
            stack.Spacing = 10;
            return stack;
        }

        void OnImageButtonClicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            Application.Current.MainPage = new NavigationPage(new ItemDetails(btn.AutomationId));
        }
    }
}