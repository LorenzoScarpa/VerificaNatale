using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ziggy.Models;
using ZiggyMongoDB = Ziggy.Classes.MongoDb;

namespace Ziggy.Controllers
{
    public class ToysController : Controller
    {
        // GET: Toys
        public ActionResult Index()
        {
            ViewBag.ScreenName = Session["ScreeName"];
            ZiggyMongoDB db = new ZiggyMongoDB();
            var toys = db.GetAllToys();
            Toys model = new Toys();
            model.EntityList = toys.ToList();
            return View(model);
        }
    }
}