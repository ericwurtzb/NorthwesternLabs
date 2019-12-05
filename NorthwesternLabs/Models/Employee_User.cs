using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    [Table("Employee_User")]
    public class Employee_User
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Password {get; set;}
        
     
    }
}