using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Data
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
        public DbSet<TeachersSubjects> TeachersSubjects { get; set; }
    }
}
