using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public partial class Course
    {
        //public Course()
        //{
        //    Student = new HashSet<Student>();
        //}
        [Key]
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }

       // public virtual ICollection<Student> Student { get; set; }
    }
}
