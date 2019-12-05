namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {[Key]
        public int InvoiceID { get; set; }

        [DisplayName("Due Date")]
        public DateTime? DueDate { get; set; }

        [DisplayName("Early Payment Date")]
        public DateTime? EarlyPaymentDate { get; set; }

        public double? Discount { get; set; }

        public double? AdvancedPaymentAmount { get; set; }

        [DisplayName("Total Due")]
        public double? TotalDue { get; set; }
    }
}
