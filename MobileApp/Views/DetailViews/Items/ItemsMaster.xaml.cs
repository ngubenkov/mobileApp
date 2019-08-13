using MobileApp.Models;
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
    public partial class ItemsMaster : ContentPage
    {
        private List<Product> productArrayList;

        public ItemsMaster()
        {
            InitializeComponent();
            productArrayList = new List<Product>();
            productArrayList.Add(new Product { Name = "Mocca" });
            productArrayList.Add(new Product { Name = "Espresso" });
            productArrayList.Add(new Product { Name = "Latte" });
            productArrayList.Add(new Product { Name = "Americano" });
            productArrayList.Add(new Product { Name = "Arabica" });

            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());

            var productIndex = 0;
            for (int rowIndex = 0; rowIndex < 2; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                {
                    if (productIndex >= productArrayList.Count)
                    {
                        break;
                    }
                    var product = productArrayList[productIndex];
                    productIndex += 1;
                    var label = new Label
                    {
                        Text = product.Name,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(label, columnIndex, rowIndex);
                }
            }
        }

        

    }
}