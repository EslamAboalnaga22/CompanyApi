using CompanyApi.Models;

namespace CompanyApi.Services
{
    public interface IDepartmentServic
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<Department> Add(Department department);
        Department Update(Department department);
        Department Delete(Department department);
        Task<bool> isValidDepartment(int id);
    }
}
