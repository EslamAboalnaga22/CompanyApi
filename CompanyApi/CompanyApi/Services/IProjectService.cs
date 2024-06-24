using CompanyApi.Models;

namespace CompanyApi.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetById(int id);
        Task<Project> Add(Project project);
        Project Update(Project project);
        Project Delete(Project project);

        
    }
}
