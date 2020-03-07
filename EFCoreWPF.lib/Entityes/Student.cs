using System.Collections.Generic;
using EFCoreWPF.Entityes.Base;

namespace EFCoreWPF.Entityes
{
    public class Student : NamedEntity
    {
        public virtual ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
    }
}
