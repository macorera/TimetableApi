using Microsoft.EntityFrameworkCore;
using TimetableApi.Models;

namespace TimetableApi.Data.Context
{
    public class TimetableContext : DbContext
    {
        public TimetableContext(DbContextOptions<TimetableContext> opt) :base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        public DbSet<Grade> Grades { get; set; }  
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<TeachersSubjects> TeachersSubjects { get; set; }
        public DbSet<GradesSubjects> GradesSubjects { get; set; }
    }
}
