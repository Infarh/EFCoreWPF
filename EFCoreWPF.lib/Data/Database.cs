using EFCoreWPF.Entityes;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF.Data
{
    public class Database : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}
