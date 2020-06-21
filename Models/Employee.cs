using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? ManagerId { get; set; }

        [ForeignKey("Role")]
        [Required]
        [Display(Name="Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Employee Manager { get; set; }
    }
}