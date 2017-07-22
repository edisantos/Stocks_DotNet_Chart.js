using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Entry
    {
        public string Date { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }

        public Entry() { }

        public Entry(string dateTime, decimal price) {
            Date = dateTime;
            Price = price;
        }

    }
}
