using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("creating")]
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO quote_wall (name, quote, created_at) VALUES ('{quote.Name}', '{quote.QuoteDetail}',now())";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> QuoteList = DbConnector.Query("SELECT * FROM quote_wall");
            ViewBag.QuoteList = QuoteList;
            return View();
        }
    }
}
