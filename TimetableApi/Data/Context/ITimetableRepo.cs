using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Data.Context
{
    public interface ITimetableRepo
    {
        bool SaveChanges();

        IEnumerable<Grade> GetAllGrades();
        Grade GetGradeById(int id);
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubjectById(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        void CreateLeave(Leave leave);
        Leave GetLeaveById(int id);
    }
}
