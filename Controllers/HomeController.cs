using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private InventoryDbContext _context;

        public HomeController()
        {
            _context = new InventoryDbContext();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(u => u.Email == employee.Email);
            if (emp == null)
               return HttpNotFound();
            Session["UserId"] = emp.Id;
            Session["UserName"] = emp.Name.ToString();
            FormsAuthentication.SetAuthCookie(emp.Name, false);
            if (emp.RoleId == 1)
            {
                Session["UserRole"] = "Manager";
                return RedirectToAction("Index", "Manager", new { emp.Id });
            }
            else
            {
                Session["UserRole"] = "Employee";
                return RedirectToAction("Index", "Employee", new { emp.Id });
            }           
        }
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            var managers = from e in _context.Employees join m in _context.Employees on e.Id equals m.ManagerId select e;
            var viewModel = new EmployeeViewModel
            {
                Roles = _context.Roles.ToList(),
                Managers = managers.Distinct().ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        
    }
}