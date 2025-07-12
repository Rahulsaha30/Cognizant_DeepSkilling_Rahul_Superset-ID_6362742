using Microsoft.AspNetCore.Mvc;
using thirdhandson.Models;  
using thirdhandson.Filters;  

namespace thirdhandson.Controllers
{
  [ApiController]
  [Route("api/emp")]
  [ServiceFilter(typeof(CustomAuthFilter))]
  public class EmployeeController : ControllerBase
  {
    private readonly List<Employee> _employees;

    public EmployeeController()
    {
      _employees = GetStandardEmployeeList();
    }


    private List<Employee> GetStandardEmployeeList()
    {
      return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Rahul",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1999, 3, 23),
                    Department = new Department
                    {
                        DeptId = 101,
                        DeptName = "HR"
                    },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, SkillName = "C#" },
                        new Skill { Id = 2, SkillName = "SQL" }
                    }
                }
            };
    }


    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), 200)]
    [ProducesResponseType(500)] // For custom exception filter
    public ActionResult<List<Employee>> Get()
    {

      // throw new Exception("Testing custom exception filter!");

      return _employees;
    }


    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
      _employees.Add(employee);
      return Ok(employee);
    }
        
        [HttpPut("{id}")]
public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
{
    
    if (id <= 0)
    {
        return BadRequest("Invalid employee id");
    }

   
    var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);

   
    if (existingEmployee == null)
    {
        return BadRequest("Invalid employee id");
    }

   
    existingEmployee.Name = updatedEmployee.Name;
    existingEmployee.Salary = updatedEmployee.Salary;
    existingEmployee.Permanent = updatedEmployee.Permanent;
    existingEmployee.Department = updatedEmployee.Department;
    existingEmployee.Skills = updatedEmployee.Skills;
    existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

    
    return Ok(existingEmployee);
}

    }
}
