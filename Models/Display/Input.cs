using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Input
    {
        public string Ticker { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public Input() { }

        public Input(string ticker, string start, string end) {
            Ticker = ticker;
            Start = start;
            End = end;
        }
    }
}
