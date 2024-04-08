using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Asset
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public double Price { get; set; }
        public Office Office { get; set; }
    }
}
