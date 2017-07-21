using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks.Models.Display
{
    public class Company
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string HeadquartersCity { get; set; }
        public string HeadquartersStateOrCountry { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }


        public Company() { }



        public Company(string symbol, string name, string headquartersCity, string 
            headquartersStateOrCountry, int numberOfEmployees, string sector, string industry) {

            Symbol = symbol;
            Name = name;
            HeadquartersCity = headquartersCity;
            HeadquartersStateOrCountry =  headquartersStateOrCountry;
            NumberOfEmployees = numberOfEmployees;
            Sector = sector;
            Industry = industry;

        }




    }
}
