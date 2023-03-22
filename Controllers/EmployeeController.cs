using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DB;

namespace ZeroHunger.Controllers
{
    [Authorize(Roles = "Employee")]

    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requests = db.Requests.Where(x => x.EmployeeId == LoginController.id);
            return View(requests);
        }
        public ActionResult Pick(int id)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requst = db.Requests.Where(x => x.Id == id).SingleOrDefault();
            requst.Status = "Employee is picked the food";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeliverReq(int id)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requst = db.Requests.Where(x => x.Id == id).SingleOrDefault();
            requst.Status = "Food is delivered to ZeroHunger";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}