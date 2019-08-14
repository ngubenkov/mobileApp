using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    class Product
    {
        public int id { get; set; }
        public int companyID { get; set; }
        public string description { get; set; } // Description1
        public double? price { get; set; }

        public Product(int ID, int CompanyID, string Name, double? price)
        {
            this.id = ID;
            this.companyID = CompanyID;
            this.description = Name;
            this.price = price;
        }
    }
}
