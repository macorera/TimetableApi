using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimetableApi.Models;

namespace TimetableApi.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) {

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithMany(s => s.Teachers)
                .UsingEntity<TeachersSubjects>(
                    ts => ts.HasOne(prop =>prop.Subject).WithMany().HasForeignKey(prop => prop.SubjectId),
                    ts => ts.HasOne(prop => prop.Teacher).WithMany().HasForeignKey(prop => prop.TeacherId),
                    ts => {
                        ts.HasKey(prop => new { prop.SubjectId, prop.TeacherId });
                    }
                );
            
            
            modelBuilder.Entity<Grade>().HasData(
                    new Grade
                    {
                        Id = 1,
                        Title = "Grade 5"
                    },
                    new Grade
                    {
                        Id = 2,
                        Title = "Grade 6"
                    });

            Student[] students = new Student[15];

            for (int i = 0; i < 15; i++)
            {
                students[i] = new Student
                {
                    Id = i + 1,
                    Name = Faker.Name.FullName(),
                    GradeId = 1

                };
            }

            modelBuilder.Entity<Student>().HasData(students);


            Teacher[] teachers = new Teacher[16];

            for (int i = 0; i < 16; i++)
            {
                teachers[i] = new Teacher
                {
                    Id = i + 1,
                    Name = Faker.Name.FullName(),
                };
            }

            modelBuilder.Entity<Teacher>().HasData(teachers);




            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Title = "Maths",
                },
                new Subject
                {
                    Id = 2,
                    Title = "English",
                },
                new Subject
                {
                    Id = 3,
                    Title = "Science",
                },
                new Subject
                {
                    Id = 4,
                    Title = "Geometry",
                },
                new Subject
                {
                    Id = 5,
                    Title = "Biology",
                },
                new Subject
                {
                    Id = 6,
                    Title = "Physics",
                },
                new Subject
                {
                    Id = 7,
                    Title = "Chemistry",
                },
                new Subject
                {
                    Id = 8,
                    Title = "World Literature",
                }


            );
        }
    }
}
