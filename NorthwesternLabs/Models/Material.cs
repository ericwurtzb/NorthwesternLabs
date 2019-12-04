namespace NorthwesternLabs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        [Key]
        public int MaterialID { get; set; }

        public int? TestID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Amount { get; set; }

        public double? Cost { get; set; }
    }
}
