using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly SchoolContext _context;

        public GradeController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Grade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            var grades = await _context.Grade.Include(g => g.Teacher).ToListAsync();
            return Ok(grades); 
        }

        // GET: api/Grade/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grade.Include(g => g.Teacher).FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null)
                return NotFound(); 

            return Ok(grade); 
        }

        [HttpPost]
        public async Task<ActionResult<Grade>> CreateGrade([FromBody] CreateGradeDto gradeDto)
        {
            // Validar existencia del Docente
            var teacherExists = await _context.Teacher.AnyAsync(t => t.Id == gradeDto.TeacherId);
            if (!teacherExists)
            {
                return NotFound("El docente especificado no existe.");
            }

            // Crear una nueva instancia de Grade usando los datos del DTO
            var newGrade = new Grade
            {
                Name = gradeDto.Name,
                TeacherId = gradeDto.TeacherId
            };

            // Agregar el Grado
            _context.Grade.Add(newGrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = newGrade.Id }, newGrade);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, Grade grade)
        {
            if (id != grade.Id) return BadRequest();

            var professorExists = await _context.Teacher.AnyAsync(p => p.Id == grade.TeacherId);
            if (!professorExists) return NotFound("Professor not found");

            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // DELETE: api/Grade/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grade.FindAsync(id);

            if (grade == null)
                return NotFound(); //  404 Not Found

            _context.Grade.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent(); //  204 No Content
        }

        private bool GradeExists(int id)
        {
            return _context.Grade.Any(e => e.Id == id);
        }
    }
}
