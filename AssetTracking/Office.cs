using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Office
    {
        public Office(string country, string currency)
        {
            Country = country;
            Currency = currency;
        }

        public string Country { get; set; }
        public string Currency { get; set; }
    }
}
