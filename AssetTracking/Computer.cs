using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Computer: Asset
    {
        public Computer(string brand, string model, DateOnly purchaseDate, double price, Office office)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            Office = office;
        }
    }
}
