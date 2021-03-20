using CalculatorClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CalculatorClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CalculatorServiceReference.CalculatorServiceSoapClient client = new CalculatorServiceReference.CalculatorServiceSoapClient(CalculatorServiceReference.CalculatorServiceSoapClient.EndpointConfiguration.CalculatorServiceSoap12);
        CalculatorFields fields = new CalculatorFields() { Avalue = 0, Bvalue = 0, Result = 0 };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(fields);
        }

        [HttpPost]
        public ActionResult Index(CalculatorFields fields, string submitButton)
        {
            switch (submitButton)
            {
                case "Add":
                    fields.Result = client.Add(fields.Avalue, fields.Bvalue);
                    break;
                case "Subtract":
                    fields.Result = client.Sub(fields.Avalue, fields.Bvalue);
                    break;
                case "Multiply":
                    fields.Result = client.Mul(fields.Avalue, fields.Bvalue);
                    break;
                case "Divide":
                    fields.Result = client.Div(fields.Avalue, fields.Bvalue);
                    break;
                default:
                    fields = new CalculatorFields() { Avalue = 0, Bvalue = 0, Result = 0 };
                    break;
            }
            
            return View(fields);
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
    }
}
