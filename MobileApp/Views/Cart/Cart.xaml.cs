using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Cart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        // listChart
        public Models.Cart cart;
 
        public Cart(Models.Cart cart)
        {
            InitializeComponent();
            this.cart = cart;
            Init();
            
        }

        void Init()
        {

            foreach(Tuple<Product,int> item in this.cart.cart)
            {
                listChart.Children.Add(createItem(item.Item1, item.Item2));
            }
            ActivitySpinner.IsVisible = false;
        }

        StackLayout createItem(Product item, int qty)
        {
            Image image = new Image{
                Source = "LoginIcon.png",
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                HeightRequest = 100,
            };

            string descriptionText = item.description ?? "no description";
            string price = item.price.ToString() ?? "no price";

            StackLayout description = new StackLayout
            {
                Children =
                {
                     new Label{ Text = descriptionText, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center },
                     new Label{ Text =  price, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center },
                },
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
            };

            StackLayout buttons = new StackLayout
            {
                Children = {
                    new Button { Text = "-", FontSize = 8, WidthRequest = 30, HeightRequest = 30 },
                    new Label { Text = "Qty", FontSize = 10, WidthRequest = 30, HeightRequest = 30 },
                    new Button { Text = "+", FontSize = 8, WidthRequest = 30, HeightRequest = 30,
                        VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                
            };

            StackLayout itemStack = new StackLayout
            {
                Children =
                {
                    image,
                    description,
                    buttons
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 10,
            };

            return itemStack;
        }

        
    }
}