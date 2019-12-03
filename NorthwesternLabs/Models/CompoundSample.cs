namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompoundSample")]
    public partial class CompoundSample
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompoundLT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompoundSequenceCode { get; set; }

        public int? AssayID { get; set; }

        public double? QuantityMg { get; set; }

        [StringLength(80)]
        public string Appearance { get; set; }
    }
}
