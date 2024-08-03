using learning.Models;

namespace learning.Interface
{
    public interface IEmployee
    {
        public Task<IEnumerable<Employee>> GetAllEmployees();
    }
}
