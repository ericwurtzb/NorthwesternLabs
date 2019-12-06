using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwesternLabs.Models
{
    public class AssayInfo
    {
        [Key]
        public int CompoundLT { get; set; }
        [DisplayName("Sample #")]
        public int CompoundSequenceCode { get; set; }
        [DisplayName("Description")]
        public string Desc { get; set; }
        [DisplayName("Estimated Completion Date")]
        public DateTime CompletionEstimate { get; set; }
        [DisplayName("Scheduled Date")]
        public DateTime DateTimeScheduled { get; set; }
        [DisplayName("Notes")]
        public string ExtraTestNotes { get; set; }
        [DisplayName("Results")]
        public string ResultsLink { get; set; }
    }
}