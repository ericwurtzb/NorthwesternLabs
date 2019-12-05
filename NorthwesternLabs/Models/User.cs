using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    public class User
    {
        public int IDNum { get; set; }
        public string Username { get; set; }
        public string Password {get; set;}
        public string Role { get; set; }
    }
}