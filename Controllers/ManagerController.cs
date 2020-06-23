using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure.MappingViews;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private InventoryDbContext _context;
        // GET: Manager
        public ManagerController()
        {
            _context = new Models.InventoryDbContext();
        }

        public ActionResult Index(int Id)
        {
            List<Item> items = _context.Items.Include(e=>e.Employee).Where(e=>e.AssignedBy ==Id).ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            var Id = Convert.ToInt32(Session["UserId"]);
            var empList = _context.Employees.Where(e => e.ManagerId == Id).ToList(); 
            var viewModel = new ItemViewModel
            {
                Employees = empList
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Item item)
        {
            var Id = Convert.ToInt32(Session["UserId"]);
            item.AssignedBy = Id;
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index","Manager", new {Id} );
        }

        [HttpGet]
        public ActionResult Edit(int id)
        
        {   var MgrId = Convert.ToInt32(Session["UserId"]);
            var Item = _context.Items.SingleOrDefault(i => i.Id == id);
            var empList = _context.Employees.Where(e => e.ManagerId == MgrId).ToList();
            var viewModel = new ItemViewModel
            {
                item = Item,
                Employees = empList
            };
            return View(viewModel);
        }

        public ActionResult SaveItems(Item item, int id)
        {
            var Id = Convert.ToInt32(Session["UserId"]);
            var itemInDb = _context.Items.SingleOrDefault(i => i.Id == id);

            itemInDb.Name = item.Name;
            itemInDb.Comments = item.Comments;
            itemInDb.Status = item.Status;
            itemInDb.AssignedTo = item.AssignedTo;
            itemInDb.AssignedBy = 1;

            _context.SaveChanges();

            return RedirectToAction("Index",new { Id});
        }

        public ActionResult Delete(int id)
        {
            var Id = Convert.ToInt32(Session["UserId"]);
            var item = _context.Items.Single(i => i.Id == id);

            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index",new { Id});
        }
    }
}
