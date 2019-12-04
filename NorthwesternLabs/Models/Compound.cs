namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compound")]
    public partial class Compound
    {
        [Key]
        [DisplayName("Compound LT Number")]
        public int CompoundLT { get; set; }

        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }

        [DisplayName("Compound Name")]
        [StringLength(50)]
        public string CompoundName { get; set; }

        [DisplayName("Date Arrived")]
        public DateTime? DateArrived { get; set; }

        [DisplayName("Date Received By")]
        public int? ReceivedBy { get; set; }

        public double? Weight { get; set; }

        public double? Mass { get; set; }

        [DisplayName("Maximum Tolerated Dose (MTD)")]
        public double? MTD { get; set; }
    }
}
