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



        public Data() { }

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
