using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stocks.Models.Display;
using System.IO;
using Microsoft.AspNetCore.Hosting;




// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stocks.Controllers
{
    public class DisplayController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public DisplayController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }





        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }






        [HttpGet]
        public IActionResult GetCompanyInfo()
        {

            string JSON;
            CompanyList cc = new CompanyList();


            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                JSON = System.IO.File.ReadAllText(contentRootPath + "/companyInfo.json");

                cc = JsonConvert.DeserializeObject<CompanyList>(JSON);

                Company c0 = cc.Companies[0];
                string s0 = c0.Name;
                
                string str = cc.Companies.ToString();

                return Content(s0);

            }
            catch (FileNotFoundException)
            {
                string err = "Not found";
                return Content(err);
            }
            catch (IOException)
            {
                string err = "IO";
                return Content(err);
            }
            catch (Exception e)
            {
                string err = "Exception occured: " + e;
                return Content(err);
            }

          


        }

        [HttpGet]
        public IActionResult GetStockInfo()
        {
            string JSON;

            string str = "";

            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                JSON = System.IO.File.ReadAllText(contentRootPath + "/historicalStockData.json");

                var data = new Data();

                var stocks = JsonConvert.DeserializeObject<List<Stock>>(JSON);

                foreach (var stock in stocks)
                {
                    if (stock.Name == "ATVI")
                    {
                        data.Stock = stock;
                       

                    }
                }

                List<string> ss1 = new List<string>();
              


                var prices = data.Stock.DailyClosePrice.Single();//TODO: parse date format
                
                  var entries = prices.Select(kvp => new { Date = kvp.Key, Price = kvp.Value });
                 foreach (var entry in entries)
                  {
                      string s1 = ($"  {entry.Date}: {entry.Price}");
                    ss1.Add(s1);
                   
                }


                string strr = "";
                foreach (string e in ss1) {
                    strr = strr + e + "\n";
                }




                return Content(strr);

            }
            catch (FileNotFoundException)
            {
                string err = "Not found";
                return Content(err);
            }
            catch (IOException)
            {
                string err = "IO";
                return Content(err);
            }
            catch (Exception e)
            {
                string err = "Exception occured: " + e;
                return Content(err);
            }


        }






      

        [HttpPost]
        public IActionResult Ticker(Data d)
        {
            string JSON;
            CompanyList cc = new CompanyList();


            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                JSON = System.IO.File.ReadAllText(contentRootPath + "/companyInfo.json");

                cc = JsonConvert.DeserializeObject<CompanyList>(JSON);

               


                var entry = from c in cc.Companies
                            where c.Symbol == d.Ticker
                            select c;
          
                if (entry.FirstOrDefault() != null)
                {
                    d.Name = entry.FirstOrDefault().Name;
                    d.Industry = entry.FirstOrDefault().Industry;
                }








              string JSON2 = System.IO.File.ReadAllText(contentRootPath + "/historicalStockData.json");

               

                var stocks = JsonConvert.DeserializeObject<List<Stock>>(JSON2);

                foreach (var stock in stocks)
                {
                    if (stock.Name == d.Ticker)
                    {
                        d.Stock = stock;


                    }
                }

                List<string> ss1 = new List<string>();



                var prices = d.Stock.DailyClosePrice.Single();//TODO: parse date format

                var entries = prices.Select(kvp => new { Date = kvp.Key, Price = kvp.Value });
                foreach (var k in entries)
                {
                    string s1 = ($"  {k.Date}: {k.Price}");
                    ss1.Add(s1);

                }


                string strr = "";
                foreach (string e in ss1)
                {
                    strr = strr + e + "\n";
                }

                d.Strr = strr;








             

                return View(d);

            }
            catch (FileNotFoundException)
            {
                string err = "Not found";
                return Content(err);
            }
            catch (IOException)
            {
                string err = "IO";
                return Content(err);
            }
            catch (Exception e)
            {
                string err = "Exception occured: " + e;
                return Content(err);
            }





            
        }



        [HttpGet("[action]/{tkr}")]
        public IActionResult Ticker(string t)
        {
            Data data = new Data();


            string s = "lolol";


            return View(s);
        }





        [HttpGet]
        public IActionResult GetLol()
        {
            string p = "lol";

            return Content(p);

           
        }



    }
}
