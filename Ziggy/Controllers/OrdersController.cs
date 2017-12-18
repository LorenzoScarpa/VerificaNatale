using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ziggy.Classes;
using Ziggy.Models;
using ZiggyMongoDB = Ziggy.Classes.MongoDb;

namespace Ziggy.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            var orders = db.GetAllOrders();
            Orders model = new Orders();
            model.EntityList = orders.ToList();
            return View(model);
        }
        public ActionResult Details(string id)
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            var model = db.GetOrderById(id);
            return View(model);
        }
        public ActionResult Edit(string id, Status status)
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            if (isAvailableOrder(id) || (status==Status.inProgress || status == Status.Done))
            {
                db.EditOrderStatus(id, status);
                return RedirectToAction("Index");
            }
            return View();
        }
        private bool isAvailableOrder(string id)
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            var toysCollection = db.GetAllToys();
            Order order = db.GetOrderById(id);
            foreach (var t1 in order.Toys)
                foreach (Toy t2 in toysCollection)
                    if (t1.Name == t2.Name && t2.Amount < 1)
                        return false;
            return true;
        }
    }
}