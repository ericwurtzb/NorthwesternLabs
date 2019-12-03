namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkOrder")]
    public partial class WorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }

        [StringLength(50)]
        public string CompoundLT { get; set; }

        public DateTime? DateDue { get; set; }

        public int? InvoiceID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(5000)]
        public string Comments { get; set; }
    }
}
