using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using CalculatorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionStatePractice;

namespace CalculatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected List<string> _history;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _history = new();
        }
        [HttpPost]
        public IActionResult Index(string input="")
        {
            //List<string> histList = new();
            //if (!String.IsNullOrWhiteSpace(history))
            //{ input = history; 
            //}
            ViewBag.Result = "";
            var result = RunCalcForWeb(input);
            if (!input.Contains("history", StringComparison.CurrentCultureIgnoreCase))//||!String.IsNullOrEmpty(result))
            {
                ViewBag.Result = result;
            }
            else if(input.Contains("history", StringComparison.CurrentCultureIgnoreCase)&& (!result.Equals("0")))//View error messages for history
            {
                ViewBag.Result = result;

            }
            else  if (_history.Count > 0){
                ViewBag.History = _history;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Result = "0.00";
            var result = HttpContext.Session.Get<string>("Result");
            if (String.IsNullOrEmpty(result)) {
                ViewBag.Result = result;
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string RunCalcForWeb(string input)
        {
            var iResult = HttpContext.Session.Get<string>("Result");
            decimal decResult;
            EvaluationResult result = new();
            Calculator calc = new();
            List<string> historyList = new();

            if (HttpContext.Session.Keys.Contains("History"))
            {
                historyList = HttpContext.Session.Get<List<String>>("History");
            }

            if (!String.IsNullOrEmpty(iResult))
            {
                bool success = Decimal.TryParse(iResult, out decResult);
                if (success) {
                    result = calc.Evaluate(input, historyList, decResult);
                }
            }
            else {
                result = calc.Evaluate(input, historyList);
            }
            if (String.IsNullOrEmpty(result.ErrorMessage)) {
                if(!String.IsNullOrEmpty(result.Result.ToString())){
                    HttpContext.Session.Set("Result", result.Result.ToString()); }
                if (result.History.Count > 0)
                {
                    //historyList.AddRange(result.History);
                    historyList=result.History;

                    _history = historyList;
                    HttpContext.Session.Set("History", historyList);
                }

                return result.Result.ToString(); 
            }
            else {
                return result.ErrorMessage;
            }
        }
    }
}
