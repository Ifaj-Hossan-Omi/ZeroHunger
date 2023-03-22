using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ZeroHunger.DB;

namespace ZeroHunger.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        public static string[] role = { "None" };
        public static int id;
        private ZeroHungerEntities db = new ZeroHungerEntities();

        // GET: Login

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Restaurants.Add(restaurant);
                    db.SaveChanges();

                    ViewBag.Message = "SignUP Successfully";
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "SignUP Failed" + e.Message;
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(Admin user)
        {
            try
            {
                if (db.Admins.Where(x => x.Username == user.Username && x.Password == user.Password).Count() != 0)
                {
                    id = db.Admins.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault().Id;

                    role = new[] { "Admin" };
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Admin");

                }
                else if (db.Restaurants.Where(x => x.Username == user.Username && x.Password == user.Password).Count() != 0)
                {
                    id = db.Restaurants.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault().Id;
                    role = new[] { "Restaurant" };
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Restaurant");

                }
                else if (db.Employees.Where(x => x.Username == user.Username && x.Password == user.Password).Count() != 0)
                {
                    id = db.Employees.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault().Id;
                    role = new[] { "Employee" };
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Employee");

                }
                else
                {
                    ViewBag.Msg = "Username or Pass incorrect";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "Login Failed" + e.Message;
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}