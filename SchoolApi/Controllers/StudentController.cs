using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Student.ToListAsync();
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }

        // PUT: api/Student/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest("Teacher ID mismatch.");

            if (!TeacherExists(id))
                return NotFound();

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                    return NotFound();

                throw;
            }

            return NoContent(); // 204 No Content
        }
        private bool TeacherExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        // DELETE: api/Student/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound(new { message = "Estudiante no encontrado." });

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }
    }
}
