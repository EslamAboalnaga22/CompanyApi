using CompanyApi.Models;

namespace CompanyApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(Employee employee);
    }
}
