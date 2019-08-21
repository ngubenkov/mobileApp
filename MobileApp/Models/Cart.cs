using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Cart
    {
        public List<Tuple<Product, int>> cart;
        public double totalAmount;
        public int totalQuantity;

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

        public void reduceQuantity(int ind)
        {
            if (cart[ind].Item2 > 2)
            {
                cart[ind] = new Tuple<Product, int>(cart[ind].Item1, cart[ind].Item2 - 1);
                updateCartTotalAmount();
                updateCartTotalQuantity();
            }

        }

        public void addQuantity(int ind)
        {
            cart[ind] = new Tuple<Product, int>(cart[ind].Item1, cart[ind].Item2 + 1);
            updateCartTotalAmount();
            updateCartTotalQuantity();
        }

        public void updateCartTotalAmount()
        {
            double total = 0.0;
            foreach (Tuple<Product, int> item in cart)
            {
                if (item.Item1.price != null)
                {
                    total += (double)item.Item1.price * item.Item2;
                }
            }
            this.totalAmount = total;
        }

        public void updateCartTotalQuantity()
        {
            int total = 0;
            foreach (Tuple<Product, int> item in cart)
            {
                total += item.Item2;
            }
            this.totalQuantity=total;
        }

    }
}
