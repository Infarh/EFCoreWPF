using System.Linq;
using EFCoreWPF.Entityes;

namespace EFCoreWPF.Services.Interfaces
{
    public interface IStudentsManager
    {
        IStudentStore Students { get; }

        void AddStudentToCourse(Student Student, string Course);

        void RemoveStudentFromCourse(Student Student, string Course);
    }
}