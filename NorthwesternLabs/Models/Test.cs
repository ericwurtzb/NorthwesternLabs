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
        public int TestID1 { get; set; }

        [StringLength(50)]
        public string TestType { get; set; }

        public bool? RerunDateTime { get; set; }

        public int? MaterialID { get; set; }

        public DateTime? DateTimeScheduled { get; set; }

        public DateTime? DateTimeCompleted { get; set; }
    }
}
