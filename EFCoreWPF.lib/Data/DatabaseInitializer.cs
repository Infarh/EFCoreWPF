using System.Linq;
using System.Threading.Tasks;
using EFCoreWPF.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF.Data
{
    public class DatabaseInitializer
    {
        private readonly Database _db;

        public DatabaseInitializer(Database db) => _db = db;

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);

            await SeedAsync(_db.Courses).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);

            await SeedAsync(_db.Students).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        private static async Task SeedAsync(DbSet<Course> Courses)
        {
            if (await Courses.AnyAsync().ConfigureAwait(false)) return;
            await Courses.AddRangeAsync(Enumerable.Range(1, 20).Select(i => new Course { Name = $"Курс {i}" })).ConfigureAwait(false);
        }

        private async Task SeedAsync(DbSet<Student> Students)
        {
            if (await Students.AnyAsync().ConfigureAwait(false)) return;
            var courses = await _db.Courses.Take(3).ToListAsync().ConfigureAwait(false);
            await Students.AddRangeAsync(Enumerable.Range(1, 20).Select(i =>
            {
                var student = new Student { Name = $"Студент {i}" };
                student.Courses = courses.Select(course => new StudentCourse { Student = student, Course = course }).ToArray();
                return student;
            })).ConfigureAwait(false);
        }
    }
}
