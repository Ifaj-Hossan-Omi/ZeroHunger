using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DB;

namespace ZeroHunger.Controllers
{
    [Authorize(Roles = "Restaurant")]

    public class RestaurantController : Controller
    {
        // GET: Restaurant

        public ActionResult Index()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requests = db.Requests.Where(x => x.RestaurantId == LoginController.id);
            return View(requests);
        }
        [HttpGet]
        public ActionResult CreateRequest()
        {
            ViewBag.Id = LoginController.id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateRequest(Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ZeroHungerEntities db = new ZeroHungerEntities();
                    db.Requests.Add(request);
                    db.SaveChanges();

                    ViewBag.Message = "Request added Successfully";
                    return RedirectToAction("Index");
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

    }
}