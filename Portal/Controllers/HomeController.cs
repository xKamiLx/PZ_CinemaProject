using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Models;
using Portal.ViewModels;

namespace Portal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<News> dbNewses = Db.Newses.ToList();
            List<NewsViewModel> newses = dbNewses.Select(dbNews => new NewsViewModel(dbNews)).ToList();

            return View(newses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}