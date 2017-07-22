using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stocks.Models.Display;
using System.IO;
using Microsoft.AspNetCore.Hosting;




namespace stocks.Controllers
{
    public class DisplayController : Controller
    {
        static void run(int resultt, int size, DateTime dt, decimal price, List<Entry> list)
        {
            for (int i = 0; i < size; i++)
            {
                if (resultt > 0)
                {
                    Entry en = new Entry()
                    {
                        DateTime = dt,
                        Price = price
                    };
                    list.Insert((i + 1), en);
                    return;
                }
            }
        }

        private readonly IHostingEnvironment _hostingEnvironment;

        public DisplayController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Data d = new Data();
            return View(d);
        }


        [HttpPost]
        public IActionResult Ticker(Data d)
        {
            d.Ticker = d.Ticker.ToUpper();
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
                var prices = d.Stock.DailyClosePrice.Single();
                var entries = prices.Select(kvp => new { Date = kvp.Key, Price = kvp.Value });
                List<Entry> list = new List<Entry>();
                foreach (var k in entries)
                {
                    decimal price = Convert.ToDecimal(($"{k.Price}"));
                    DateTime dt = DateTime.Parse(k.Date);
                    DateTime dt0 = DateTime.Parse(d.Start);
                    DateTime dtf = DateTime.Parse(d.End);
                    int result1 = DateTime.Compare(dt, dt0);
                    int result2 = DateTime.Compare(dtf, dt);
                    if (result1 >= 0 && result2 >= 0)
                    {
                        int result = DateTime.Compare(dt, dt0);
                        int resultt = 0;
                        int size = list.Count();
                        if (list.Any() == true)
                        {
                            resultt = DateTime.Compare(dt, list[0].DateTime);
                        }
                        if (result > 0)
                        {
                            if (list.Any() == false)
                            {
                                Entry en = new Entry()
                                {
                                    DateTime = dt,
                                    Price = Convert.ToDecimal(($"{k.Price}"))
                                };
                                list.Insert(0, en);
                            }
                            else if (resultt < 0)
                            {
                                Entry en = new Entry()
                                {
                                    DateTime = dt,
                                    Price = Convert.ToDecimal(($"{k.Price}"))
                                };
                                list.Insert(0, en);
                            }
                            else
                            {
                                run(resultt, size, dt, price, list);
                            }
                        }
                    }
                }             
                list.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));
                string[] dates = new string[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    dates[i] = list[i].DateTime.ToString("M/d/yy");
                }
                d.Dates = dates;
                decimal[] prices2 = new decimal[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    prices2[i] = list[i].Price;
                }
                d.Prices = prices2;
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
    }
}
