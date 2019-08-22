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
        List<Label> labels;
        public Cart(Models.Cart cart)
        {
            InitializeComponent();
            this.cart = cart;
            labels = new List<Label>();
            Init();
            
        }

        async void Init()
        {
            if (this.cart.cart.Count == 0) // empty cart case
            {
                listCart.Children.Add(new Label { Text = "Your cart is emprty", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center });
            }
            else // cart contains items
            {
                foreach (Tuple<Product, int> item in this.cart.cart)
                {
                    listCart.Children.Add(createItem(item.Item1, item.Item2));
                }
            }
            await updateTotals();
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

            Button btnMinus = new Button
            {
                Text = "-",
                FontSize = 8,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                ClassId = item.id.ToString()
            };
            btnMinus.Clicked += removeItem;

            Button btnPluss = new Button
            {
                Text = "+",
                FontSize = 8,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                ClassId = item.id.ToString()
            };
            btnPluss.Clicked += addItem;

            Label lblQty = new Label
            {
                Text = qty.ToString(),
                FontSize = 10,
                WidthRequest = 30,
                HeightRequest = 30,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                ClassId = "lbl" + item.id.ToString(),
                AutomationId = "lbl" + item.id.ToString(), 
            };
            labels.Add(lblQty); // add label to label list

            StackLayout buttons = new StackLayout
            {
                Children = {
                    btnMinus,
                    lblQty,
                    btnPluss,
                },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = item.id.ToString(),
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

        async void addItem(object sender, EventArgs e)
        {
           Button btn = (Button)sender;
            // btn.ClassId
           int ind = 0;
           foreach(Tuple<Product,int> item in cart.cart)
           {
                if(item.Item1.id.ToString() == btn.ClassId)
                {
                    cart.addQuantity(ind);
                    break;
                }
                ind++;     
           }
            labels[ind].Text = cart.cart[ind].Item2.ToString();
            
            await updateTotals();
        }
        async void removeItem(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // btn.ClassId
            int ind = 0;
            foreach (Tuple<Product, int> item in cart.cart)
            {
                if (item.Item1.id.ToString() == btn.ClassId)
                {
                    cart.reduceQuantity(ind);
                    break;
                }
                ind++;
            }
            labels[ind].Text = cart.cart[ind].Item2.ToString();
            await updateTotals();
        }

        async Task updateTotals()
        {
            lbl_totalQty.Text = this.cart.totalQuantity.ToString() ;
            lbl_totalAmount.Text = this.cart.totalAmount.ToString();
        }
    }
}