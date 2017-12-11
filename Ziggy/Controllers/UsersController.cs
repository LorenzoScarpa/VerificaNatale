using System.Web.Mvc;
using Ziggy.Classes;
using MongoDB.Bson;
using Ziggy.Models;
using System;
using System.Linq;
using ZiggyMongoDB = Ziggy.Classes.MongoDb;

namespace Ziggy.Controllers
{
    public class UsersController : Controller
    {

        // GET

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            var usr = db.GetUser(user);
            if (usr != null)
            {
                Session["UserName"] = usr.Email.ToString();
                Session["ScreenName"] = usr.ScreenName.ToString();
                Session["ID"] = usr.Id.ToString();
                return RedirectToAction($"../Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password Error");
            }
            return View();
        }
    }
}