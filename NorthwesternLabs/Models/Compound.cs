namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compound")]
    public partial class Compound
    {
        [Key]
        public int CompoundLT { get; set; }

        [StringLength(50)]
        public string CompoundName { get; set; }

        public DateTime? DateArrived { get; set; }

        public int? ReceivedBy { get; set; }

        public double? Weight { get; set; }

        public double? Mass { get; set; }

        public DateTime? ConfirmationDateTime { get; set; }

        public double? MTD { get; set; }
    }
}
