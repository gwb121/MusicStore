using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        MusicStoreEntity db = new MusicStoreEntity();
        public ActionResult Index()
        {
            List<Orders> orderList = db.Orders.Where(p => p.Username == User.Identity.Name).ToList();
            return View(orderList);
        }
        public ActionResult Details(int id)
        {
            List<OrderDetails> orderDetailList = db.OrderDetails.Where(p => p.OrderId == id).ToList();

            return View(orderDetailList);
        }
       
    }
}