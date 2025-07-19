using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCOREWEB.Model;
using EFCOREWEB.Data;

namespace EFCOREWEB
{
  [ApiController]
  [Route("api/[controller]")]
  public class CourseController : ControllerBase
  {
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostCourse([FromBody] Course course)
    {
      await _context.Courses.AddAsync(course);
      await _context.SaveChangesAsync();
      return Ok(course);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
      var course = await _context.Courses.ToListAsync();
      return Ok(course);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var course = await _context.Courses.FindAsync(id);
      if (course == null) return NotFound();
      return Ok(course);
     }

  }
}