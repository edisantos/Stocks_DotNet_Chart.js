using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Entry
    {
        public string Date { get; set; }
        public double Price { get; set; }

        public Entry() { }

        public Entry(string date, double price) {
            Date = date;
            Price = price;
        }

    }
}
