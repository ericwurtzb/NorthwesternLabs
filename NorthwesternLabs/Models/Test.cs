namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        [Key]
        [Column("TestID")]
        public int TestID { get; set; }

        public int? AssayID { get; set; }

        [StringLength(50)]
        public string TestType { get; set; }

        public bool? RerunBool { get; set; }

        public DateTime? DateTimeScheduled { get; set; }

        public DateTime? DateTimeCompleted { get; set; }
    }
}
