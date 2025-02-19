using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsGradeController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsGradeController (SchoolContext context)
        {
            _context = context;
        }

        // Obtener todas las relaciones StudentGrade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentGrades()
        {
            var studentGrades = await _context.StudentGrade
                .Include(sg => sg.Student)
                .Include(sg => sg.Grade)
                .Select(sg => new
                {
                    sg.Id,
                    StudentName = sg.Student.Name + " " + sg.Student.LastName,
                    GradeName = sg.Grade.Name,
                    sg.Section
                })
                .ToListAsync();

            return Ok(studentGrades);
        }

        [HttpPost]
        public async Task<ActionResult<StudentGrade>> CreateStudentGrade([FromBody] StudentGradeCreateDto studentGradeDto)
        {
            // Validar existencia del Estudiante
            var studentExists = await _context.Student.AnyAsync(s => s.Id == studentGradeDto.StudentId);
            if (!studentExists)
            {
                return NotFound("El estudiante especificado no existe.");
            }

            // Validar existencia del Grado
            var gradeExists = await _context.Grade.AnyAsync(g => g.Id == studentGradeDto.GradeId);
            if (!gradeExists)
            {
                return NotFound("El grado especificado no existe.");
            }

            // Prevenir duplicados
            var existingRelationship = await _context.StudentGrade
                .AnyAsync(sg => sg.StudentId == studentGradeDto.StudentId && sg.GradeId == studentGradeDto.GradeId);
            if (existingRelationship)
            {
                return Conflict("Ya existe una relación entre el estudiante y el grado especificado.");
            }

            // Crear nueva relación
            var newStudentGrade = new StudentGrade
            {
                StudentId = studentGradeDto.StudentId,
                GradeId = studentGradeDto.GradeId,
                Section = studentGradeDto.Section
            };

            _context.StudentGrade.Add(newStudentGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentGrades), new { id = newStudentGrade.Id }, newStudentGrade);
        }



        // Eliminar una relación StudentGrade
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGrade(int id)
        {
            var studentGrade = await _context.StudentGrade.FindAsync(id);

            if (studentGrade == null)
            {
                return NotFound("Relación no encontrada.");
            }

            _context.StudentGrade.Remove(studentGrade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
