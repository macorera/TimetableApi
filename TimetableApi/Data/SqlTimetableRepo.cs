using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Data
{
    public class SqlTimetableRepo : ITimetableRepo
    {
        private readonly TimetableContext _context;

        public SqlTimetableRepo(TimetableContext context)
        {
            _context = context;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _context.Grades.ToArray();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToArray();
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects.Include(subject => subject.Teachers).ToArray();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Grade GetGradeById(int id)
        {
            return _context.Grades.FirstOrDefault(p => p.Id == id);
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.Id == id);
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.Include(subject => subject.Teachers).FirstOrDefault(p => p.Id == id);
        }

        public Teacher GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
