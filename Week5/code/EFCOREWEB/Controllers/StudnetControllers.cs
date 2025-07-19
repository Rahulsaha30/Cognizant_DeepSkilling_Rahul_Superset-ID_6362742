using EFCOREWEB.Model;
using EFCOREWEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Data.SqlTypes;
using Microsoft.Identity.Client;
using System.Data;
using EFCOREWEB.DTO;
using Microsoft.AspNetCore.Authorization;

namespace EFCOREWEB.Controllers
{

    [Authorize]
  [ApiController]
  [Route("api/[controller]")]


  public class StudentController : ControllerBase
  {
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] Student student)
    {
      await _context.Students.AddAsync(student);
      await _context.SaveChangesAsync();
      return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var students = await _context.Students.Include(s => s.courses)
      .AsNoTracking().ToListAsync();
      return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var student = await _context.Students.
      Include(s => s.courses).
      FirstOrDefaultAsync(c => c.Id == id);

      if (student == null) return NotFound();

      var dto = new StudentDto
      {
        Name = student.Name,
        Email = student.Email,
        Courses = student.courses.Select(c => c.CourseName).ToList()

      };
      return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student updatedStudent)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound();
      student.Name = updatedStudent.Name;
      student.Age = updatedStudent.Age;
      student.Email = updatedStudent.Email;
      await _context.SaveChangesAsync();
      return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound();
      _context.Students.Remove(student);
      await _context.SaveChangesAsync();
      return Ok("Deleted");

    }

    [HttpPost("{studentId}/enroll/{courseId}")]
    public async Task<IActionResult> EnrollCourse(int studentId, int courseId)
    {
      var student = await
       _context.Students.
       Include(S => S.courses).FirstOrDefaultAsync(s => s.Id == studentId);

      var course = await _context.Courses.FindAsync(courseId);
      if (student == null || course == null)
      {
        return NotFound();
      }

      if (!student.courses.Any(c => c.Id == courseId))
      {
        student.courses.Add(course);
      }
      await _context.SaveChangesAsync();
      return Ok("Student enrolled");
    }
  }
}