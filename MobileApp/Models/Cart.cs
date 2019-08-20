using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Cart
    {
        public List<Tuple<Product, int>> cart;
        private double total;

        public Cart()
        {
            this.cart = new List<Tuple<Product, int>>();
        }

        public void addItemToCart(Product product, int quantity) // add item to chart
        {
            this.cart.Add(new Tuple<Product, int>(product, quantity));
        }

        public void removeItemFromCart(int ind) // remove item by index
        {
            cart.RemoveAt(ind);
        }

        public double getCartTotal()
        {
            double total = 0.0;
            foreach (Tuple<Product, int> item in cart)
            {
                if (item.Item1.price != null)
                {
                    total += (double)item.Item1.price * item.Item2;
                }
            }
            return total;
        }

    }
}
