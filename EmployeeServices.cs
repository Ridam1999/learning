using learning.Interface;
using learning.Models;
using Microsoft.EntityFrameworkCore;

namespace learning.Services
{

    public class EmployeeServices :IEmployee
    {
        private readonly EmployeeContext _dbContext;
        public EmployeeServices(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            
            var employees = await _dbContext.Employees.ToListAsync();
            //var employees = await (from e in _dbContext.Employees
            //                       select e).ToListAsync();
            return employees;
        }
    }
}
