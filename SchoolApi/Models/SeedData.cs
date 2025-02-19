using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;

namespace SchoolApi.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SchoolContext>>()))
            {              
                if (context.Student.Any())
                {
                    return;
                }
                else
                {
                    context.Student.AddRange(new Student { Id = 1, BirthDate = DateTime.Now, Gender ="f", LastName="Perez", Name= "Juan" });
                }
                if (context.Teacher.Any())
                {
                    return;
                }
                else
                {
                    context.Teacher.AddRange(new Teacher { Id= 1, Gender = "f", LastName = "Perez", Name = "Juan" });
                }
                if (context.Grade.Any())
                {
                    return;
                }
                else
                {
                    context.Grade.AddRange(new Grade { Id = 1, Name = "Grado 6", TeacherId = 1 });
                }
                if (context.StudentGrade.Any())
                {
                    return;
                }
                else
                {
                    context.StudentGrade.AddRange(new StudentGrade {Id=1, StudentId=1, GradeId=1, Section="Math" });
                }

            }
        }
    }
}
