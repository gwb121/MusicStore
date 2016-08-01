using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()                                     ///首页动作
        {
            Models.MusicStoreEntity db = new Models.MusicStoreEntity();///实例化数据访问对象db
            var dbal=db.Albums.ToList();                               ///var 方式获取albums表
            List<Albums> dbal1 = db.Albums.OrderBy(a=>a.Title).Where(a=>a.Title.CompareTo("d")>0).ToList();    /// list 方式获取上表
            ViewBag.dbal = db.Albums.ToList();                          ///用viewbag传参数
            return View(dbal1);                                         ///用参数形式传数据
        }

        public ActionResult About()
        {
            ViewBag.Message = "你的关于消息写在这里.哈哈哈哈。。。。。。";
            ViewData["GWB"] = "jdgnlksdnklgdsklg";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.GWB = "sdk;ksfdmsfd但是看看";
            return View();
        }
    }
}