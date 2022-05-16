using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public partial class Student
    {
        //public Student()
        //{
        //    Note = new HashSet<Note>();
        //}
        [Key]
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string City { get; set; }
        public bool State { get; set; }
        public int IdCourse { get; set; }

        //public virtual Course IdCourseNavigation { get; set; }
        //public virtual ICollection<Note> Note { get; set; }
    }
}
