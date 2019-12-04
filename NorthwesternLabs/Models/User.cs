using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password {get; set;}
        
        public int? EmployeeID { get; set; }

        public int? CustomerID { get; set; }
    }
}