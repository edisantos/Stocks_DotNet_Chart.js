using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Data
    {
        public string Ticker { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public List<Entry> Entries { get; set; }
        public string Strr { get; set; }

        public Stock Stock { get; set; }

        public string[] Dates { get; set; }
        public decimal[] Prices { get; set; }


        public Data() {
            Ticker = "ATVI";
            Start = "1/5/2017";
            End = "3/13/2017";
            Dates = new string[] { "6/7", "6/5", "3/6","6/7", "6/5", "3/6","8/9","4/5","3/2" };
        }

        public Data(string ticker, string start, string end, string name, string industry, List<Entry> entries)
        {
            Ticker = ticker;
            Start = start;
            End = end;
            Name = name;
            Industry = industry;
            Entries = entries;


        }





    }
}
