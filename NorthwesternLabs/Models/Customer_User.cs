using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    [Table("Customer_User")]
    public class Customer_User
    {
        [Key]
        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string Password {get; set;}
       

        
    }
}