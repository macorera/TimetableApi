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
                        ts.Property(prop => prop.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                    }
                );

            modelBuilder.Entity<Grade>()
                .HasMany(g => g.Subjects)
                .WithMany(s => s.Grades)
                .UsingEntity<GradesSubjects>(
                    gs => gs.HasOne(prop => prop.Subject).WithMany().HasForeignKey(prop => prop.SubjectId),
                    gs => gs.HasOne(prop => prop.Grade).WithMany().HasForeignKey(prop => prop.GradeId),
                    gs => {
                        gs.HasKey(prop => new { prop.SubjectId, prop.GradeId });
                        gs.Property(prop => prop.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
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

            Student[] students = new Student[5];

            for (int i = 0; i < 5; i++)
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

            modelBuilder.Entity<TeachersSubjects>().HasData(
                new TeachersSubjects
                {
                    TeacherId = 1,
                    SubjectId = 1
                },
                new TeachersSubjects
                {
                    TeacherId = 2,
                    SubjectId = 1
                },
                new TeachersSubjects
                {
                    TeacherId = 3,
                    SubjectId = 2
                },
                new TeachersSubjects
                {
                    TeacherId = 4,
                    SubjectId = 2
                },
                new TeachersSubjects
                {
                    TeacherId = 5,
                    SubjectId = 3
                },
                new TeachersSubjects
                {
                    TeacherId = 6,
                    SubjectId = 3
                },
                new TeachersSubjects
                {
                    TeacherId = 7,
                    SubjectId = 4
                },
                new TeachersSubjects
                {
                    TeacherId = 8,
                    SubjectId = 4
                },
                new TeachersSubjects
                {
                    TeacherId = 9,
                    SubjectId = 5
                },
                new TeachersSubjects
                {
                    TeacherId = 10,
                    SubjectId = 5
                },
                new TeachersSubjects
                {
                    TeacherId = 11,
                    SubjectId = 6
                },
                new TeachersSubjects
                {
                    TeacherId = 12,
                    SubjectId = 6
                },
                new TeachersSubjects
                {
                    TeacherId = 13,
                    SubjectId = 7
                },
                new TeachersSubjects
                {
                    TeacherId = 14,
                    SubjectId = 7
                },
                new TeachersSubjects
                {
                    TeacherId = 15,
                    SubjectId = 8
                },
                new TeachersSubjects
                {
                    TeacherId = 16,
                    SubjectId = 8
                }
                );


            modelBuilder.Entity<GradesSubjects>().HasData(
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 1
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 2
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 3
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 4
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 5
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 6
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 7
                },
                new GradesSubjects
                {
                    GradeId = 1,
                    SubjectId = 8
                }
                );

            var dates = new List<DateTime>();
            Timetable[] timetables = new Timetable[40];

            int index = 0;
            for (var dt = DateTime.Parse("2021-01-11 00:00:00"); dt <= DateTime.Parse("2021-01-15 00:00:00"); dt = dt.AddDays(1))
            {
                
                DateTime rec = dt.ChangeTime(8,0,0,0);
                for (int i = 0; i < 8; i++)
                {
                    timetables[index] = new Timetable
                    {
                        Id = index+1,
                        GradeId = 1,
                        TeacherId = (i == 0 ? 1 : i+2),
                        SubjectId = i + 1,
                        StartAt = rec,
                        EndsAt = rec.AddMinutes(45),
                    };
                    rec = rec.AddMinutes(45);

                    index++;
                }

                
            }

            modelBuilder.Entity<Timetable>().HasData(
                timetables
            );


        }

        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
    }
}
