using EFCoreWPF.Entityes.Base;

namespace EFCoreWPF.Entityes
{
    public class StudentCourse : BaseEntity
    {
        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}