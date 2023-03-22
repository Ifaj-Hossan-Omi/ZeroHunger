using System.Collections.Generic;
using ZeroHunger.DB;
using ZeroHunger.Models;

namespace ZeroHunger.Repo
{
    public class EmployeeRepo
    {
        public static List<EmployeeModel> Get()
        {
            ZeroHungerEntities db = new ZeroHungerEntities();
            var employees = new List<EmployeeModel>();
            foreach (var item in db.Employees)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return employees;
        }
        public static EmployeeModel Get(int id)
        {
            var db = new ZeroHungerEntities();
            var dbct = db.Employees.Find(id);
            return new EmployeeModel()
            {
                Id = dbct.Id,
                Name = dbct.Name
            };
        }
        public static void Create(EmployeeModel employee)
        {
            var db = new ZeroHungerEntities();
            db.Employees.Add(new Employee()
            {
                Id = employee.Id,
                Name = employee.Name

            });
            db.SaveChanges();

        }
    }
}
