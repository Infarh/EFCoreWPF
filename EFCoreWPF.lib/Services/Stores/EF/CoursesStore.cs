using System;
using System.Linq;
using EFCoreWPF.Data;
using EFCoreWPF.Entityes;
using EFCoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF.Services.Stores.EF
{
    class CoursesStore : DataStore<Course>, ICoursesStore
    {
        public override IQueryable<Course> Items => base.Items.Include(c => c.Students).ThenInclude(sc => sc.Student);

        public CoursesStore(Database db) : base(db) { }

        public Course GetByName(string Name) => Items.FirstOrDefault(c => c.Name == Name);

        public override void Update(int id, Course item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = Get(id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            if (item.Name != null)
                db_item.Name = item.Name;
            db_item.Students = item.Students?.Select(c => new StudentCourse { Student = c.Student, Course = db_item }).ToArray();
        }
    }
}