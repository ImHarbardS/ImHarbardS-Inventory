using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private InventoryDbContext _context;

        public EmployeeController()
        {
            _context = new InventoryDbContext();
        }
        // GET: Employee
        public ActionResult Index(int Id)
        {
            
            List < Item > items = _context.Items.Include(e => e.Employee).Where(e => e.AssignedTo == Id).ToList();
            return View(items);
        }

        public ActionResult Edit(int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(i => i.Id == id);
            return View(itemInDb);
        }

        public ActionResult SaveItems(Item item, int id)
        {
            var itemInDb = _context.Items.SingleOrDefault(i => i.Id == id);
            int Id = 0;
            if(itemInDb != null)
            {
                Id = Convert.ToInt32(Session["UserId"]);
                itemInDb.Comments = item.Comments;
                itemInDb.Status = item.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index",new{Id});
        }
    }
}