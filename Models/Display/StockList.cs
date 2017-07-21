using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class StockList
    {
        public List<Stock> Stocks { get; set; }

        public StockList() { }

        public StockList(List<Stock> stocks)
        {
            Stocks = stocks;
        }
    }
}
