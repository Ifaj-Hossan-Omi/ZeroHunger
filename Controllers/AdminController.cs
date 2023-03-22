using System;
using System.Linq;
using System.Web.Mvc;
using ZeroHunger.DB;

namespace ZeroHunger.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requests = db.Requests.Where(x => x.EmployeeId == null);
            return View(requests);
        }
        [HttpGet]
        public ActionResult AssignEmployee(int requestId)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var employees = db.Employees;
            ViewBag.requestId = requestId;
            return View(employees);
        }
        public ActionResult Assigned(int employeeId, int requestId)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requst = db.Requests.Where(x => x.Id == requestId).SingleOrDefault();
            requst.EmployeeId = employeeId;
            requst.Status = "Employee is coming for collect the food";
            db.SaveChanges();
            return RedirectToAction("AllRequests");
        }
        public ActionResult AllRequests()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var requests = db.Requests;
            return View(requests);
        }
        public ActionResult AllEmployee()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var employees = db.Employees;
            return View(employees);
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            ZeroHungerEntities db = new ZeroHungerEntities();

            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();

                    ViewBag.Message = "Employee Add Successfully";
                    return RedirectToAction("AllEmployee");
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