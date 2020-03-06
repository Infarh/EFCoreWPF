using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreWPF.Entityes;
using EFCoreWPF.Services.Interfaces;

namespace EFCoreWPF.Services
{
    internal class StudentsesManager : IStudentsManager
    {
        private readonly IStudentStore _Students;
        private readonly ICoursesStore _Courses;

        public IStudentStore Students => _Students;

        public StudentsesManager(IStudentStore Students, ICoursesStore Courses)
        {
            _Students = Students;
            _Courses = Courses;
        }

        public void AddStudentToCourse(Student Student, string Course)
        {
            if (Student.Courses.Any(c => c.Course.Name == Course)) return;

            var db_course = _Courses.GetByName(Course);
            if (db_course is null)
                throw new InvalidOperationException($"Курс {Course} отсутствует в базе данных");

            Student.Courses.Add(new StudentCourse(Student, db_course));
            _Students.SaveChanges();
        }

        public void RemoveStudentFromCourse(Student Student, string Course)
        {
            foreach (var course in Student.Courses.Where(c => c.Course.Name == Course).ToArray())
                Student.Courses.Remove(course);
        }
    }
}
