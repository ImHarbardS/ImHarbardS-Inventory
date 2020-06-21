using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Item Name")]
        public string Name { get; set; }
        [ForeignKey("Employee")]

        [Required]
        [Display(Name="Assign To")]
        public int AssignedTo { get; set; }

        [Display(Name="Manager Name")]
        public int? AssignedBy { get; set; }

        public Employee Employee { get; set; }

        public string Comments { get; set; }
        public string Status { get; set; }
    }
}