using GithubSecretToIISEnvWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GithubSecretToIISEnvWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;     
        }
        public IActionResult Index()
        {
            Dictionary<string, string> envVars = new Dictionary<string, string>();
            var defaultConnection = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            envVars.Add("DefaultConnection", defaultConnection ?? "");
            var appUrl = _configuration.GetValue<string>("AppURL");
            envVars.Add("AppURL", appUrl ?? "");
            var apiKey = _configuration.GetValue<string>("APIKey");
            envVars.Add("APIKey", apiKey ?? "");
            ViewBag.EnvironmentVars = envVars;

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
    }
}
