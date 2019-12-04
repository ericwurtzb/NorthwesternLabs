namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assay")]
    public partial class Assay
    {
        [Key]
        public int AssayID { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        [StringLength(50)]
        public string Protocol { get; set; }

        public DateTime? CompletionEstimate { get; set; }

        public DateTime? DateTimeScheduled { get; set; }

        public DateTime? DateTimeCompleted { get; set; }

        public double? BasePrice { get; set; }

        [StringLength(5000)]
        public string ExtraTestNotes { get; set; }

        [StringLength(5000)]
        public string ResultsLink { get; set; }
    }
}
