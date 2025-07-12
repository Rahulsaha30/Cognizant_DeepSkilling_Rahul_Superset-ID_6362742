using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fifthhandson.Models;

namespace fifthhandson.Controllers
{
    [ApiController]
    [Route("api/emp")]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Rahul",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(1999, 3, 23),
                Department = new Department { DeptId = 1, DeptName = "HR" },
                Skills = new List<Skill> {
                    new Skill { Id = 1, SkillName = "C#" },
                    new Skill { Id = 2, SkillName = "SQL" }
                }
            }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(_employees);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Update(int id, [FromBody] Employee emp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return BadRequest("Invalid employee id");

            
            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.DateOfBirth = emp.DateOfBirth;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;

            return Ok(existing);
        }
    }
}
