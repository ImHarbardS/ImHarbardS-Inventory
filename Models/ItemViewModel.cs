using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class ItemViewModel
    {
        public Item item { get; set; }
        public List<Employee> Employees { get; set; }
    }
}