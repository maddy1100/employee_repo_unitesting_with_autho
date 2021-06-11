using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class EmployeeService : IEmployeeService
    {
        private AppDbContext _appDbContext;

        public EmployeeService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void addEmployee(Employee employee)
        {
            _appDbContext.Add(employee);
        }

        public void deleteEmployee(int empId)
        {
            _appDbContext.Employees.Remove(getEmployeeDetails(empId));
        }

        public Employee getEmployeeDetails(int empId)
        {
            return _appDbContext.Employees.Find(empId);
        }

        public List<Employee> getEmployeeList()
        {
            return _appDbContext.Employees.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync() > 0);
        }
    }
}
