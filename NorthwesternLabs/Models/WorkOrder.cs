namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkOrder")]
    public partial class WorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }

        [DisplayName("Customer ID")]
        public int? CustomerID { get; set; }

        [DisplayName("Invoice ID")]
        public int? InvoiceID { get; set; }

        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [DisplayName("Confirmation Sent")]
        public bool? ConfirmationSent { get; set; }

        [DisplayName("Confirmation Date")]
        public DateTime? ConfirmationDate {get; set;}

        [StringLength(5000)]
        public string Comments { get; set; }

        [DisplayName("Employee ID")]
        public int? EmployeeID { get; set; }
    }
}
