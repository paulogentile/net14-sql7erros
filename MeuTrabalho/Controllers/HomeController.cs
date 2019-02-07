using MeuTrabalho.Repo;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        private ILogRepository _log;
        public HomeController(ILogRepository logRepository)
        {
            _log = logRepository;
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            ViewBag.Name = name ?? throw new ArgumentNullException(name);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            _log.InsertLog("about");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            _log.InsertLog("contact");

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
