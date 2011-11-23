using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Markd.Services;

namespace Markd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DummyMarkdownService _service;
        public HomeController()
        {
            _service = new DummyMarkdownService(AppDomain.CurrentDomain.GetData("DataDirectory").ToString());
        }

        public ActionResult Index()
        {
            var model = _service.All();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
