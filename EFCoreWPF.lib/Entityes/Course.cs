using System.Collections.Generic;
using EFCoreWPF.Entityes.Base;

namespace EFCoreWPF.Entityes
{
    public class Course : NamedEntity
    {
        public virtual ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }
}