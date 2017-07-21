using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Stock
    {
        public string Name { get; set; }
        public List<Dictionary<string, decimal>> DailyClosePrice { get; set; }
    }
}
