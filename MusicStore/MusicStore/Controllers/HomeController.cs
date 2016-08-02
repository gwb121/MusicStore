using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MusicStoreEntity db = new MusicStoreEntity();
            List<Albums> list = db.Albums.OrderByDescending(a=>a.OrderDetails.Count).Take(12).ToList();
            //ViewBag.List = list;
            return View(list);
        }



        public ActionResult About()
        {
            ViewBag.Message = "";
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
    }
}