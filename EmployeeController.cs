using learning.Interface;
using learning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            _employee.GetAllEmployees();

            
            return _employee.GetAllEmployees(); ;
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_dbContext.Employees == null)
            {
                return NotFound();
            }
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

            //var employee = await (from e in _dbContext.Employees
            //                      where e.EmployeeId == id
            //                      select e).FirstOrDefaultAsync();


            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            // Ensure that the EmployeeId is not set explicitly
            if (employee.EmployeeId != 0)
            {
                employee.EmployeeId = 0;
            }
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            // var employee = await (from e in _dbContext.Employees
            //                       where e.EmployeeId == employee.EmployeeId
            //                       select e).FirstOrDefaultAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId}, employee);
        }
    }
}
