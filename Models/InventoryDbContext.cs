using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace InventoryManagement.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext() : base ("InventoryDb")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}