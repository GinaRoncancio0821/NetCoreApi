using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public partial class Programs
    {
        //public Programs()
        //{
        //    Note = new HashSet<Note>();
        //}

        [Key]
        public int IdProgram { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }

       // public virtual ICollection<Note> Note { get; set; }
    }
}
