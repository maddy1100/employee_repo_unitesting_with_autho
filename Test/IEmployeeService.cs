using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    public interface IEmployeeService
    {
        List<Employee> getEmployeeList();
        Employee getEmployeeDetails(int empId);
        void addEmployee(Employee employee);
        void deleteEmployee(int empId);

        Task<bool> SaveChangesAsync();
    }
}
