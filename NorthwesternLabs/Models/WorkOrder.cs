using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }
        public string CompoundLT { get; set; }
        public DateTime DateDue { get; set; }
        public int InvoiceID { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }
}