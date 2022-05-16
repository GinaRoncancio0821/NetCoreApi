using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public partial class Note
    {
        [Key]
        public long IdNote { get; set; }
        public string Activity { get; set; }
        public int IdStudent { get; set; }
        public int IdProgram { get; set; }
        public double? Note1 { get; set; }
        public DateTime? Date { get; set; }
        public bool State { get; set; }

       // public virtual Programs IdProgramNavigation { get; set; }
       // public virtual Student IdStudentNavigation { get; set; }
    }
}
