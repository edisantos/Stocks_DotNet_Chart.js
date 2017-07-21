using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class CompanyList
    {
        public List<Company> Companies { get; set; }

        public CompanyList() { }

        public CompanyList(List<Company> companies) {
            Companies = companies;
        }
    }
}
