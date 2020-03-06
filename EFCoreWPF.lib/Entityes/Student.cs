using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.Entityes.Base;

namespace EFCoreWPF.Entityes
{
    public class Student : NamedEntity
    {
        public virtual ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
    }

    public class Course : NamedEntity
    {
        public virtual ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }

    public class StudentCourse
    {
        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}
