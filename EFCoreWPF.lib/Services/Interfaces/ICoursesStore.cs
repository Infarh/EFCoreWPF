using EFCoreWPF.Entityes;

namespace EFCoreWPF.Services.Interfaces
{
    public interface ICoursesStore : IDataStore<Course>
    {
        Course GetByName(string Name);
    }
}