using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreWPF.Data;
using EFCoreWPF.Entityes;
using EFCoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF.Services.Stores.EF
{
    internal class StudentsStore : DataStore<Student>, IStudentStore
    {
        public override IQueryable<Student> Items => base.Items.Include(s => s.Courses).ThenInclude(sc => sc.Course);

        public StudentsStore(Database db) : base(db) { }

        public override void Update(int id, Student item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = Get(id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            if (item.Name != null)
                db_item.Name = item.Name;
            db_item.Courses = item.Courses?.Select(c => new StudentCourse { Student = db_item, Course = c.Course }).ToArray();
        }
    }
}
