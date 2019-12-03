namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {[Key]
        public int InvoiceID { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? EarlyPaymentDate { get; set; }

        public double? Discount { get; set; }

        public double? AdvancedPaymentAmount { get; set; }

        public double? TotalDue { get; set; }
    }
}
