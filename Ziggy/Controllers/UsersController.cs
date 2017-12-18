using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Ziggy.Classes;
using ZiggyMongoDB = Ziggy.Classes.MongoDb;

namespace Ziggy.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            ZiggyMongoDB db = new ZiggyMongoDB();
            user.Password = SHA512(user.Password);
            var usr = db.GetUser(user);
            if (usr != null)
            {
                Session["ScreenName"] = usr.ScreenName.ToString();
                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password Error");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["ScreenName"] != null)
            {
                Session.Clear();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        private string SHA512(string String)
        {
            byte[] hashValue;
            byte[] message = Encoding.UTF8.GetBytes(String);
            SHA512Managed hashString = new SHA512Managed();
            hashValue = hashString.ComputeHash(message);
            StringBuilder sb = new StringBuilder();
            foreach(byte b in hashValue)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}