using CompanyApi.Data;
using CompanyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects
                .Include(d => d.Department)
                .ToListAsync();
        }
        public async Task<Project> GetById(int id)
        {
            return await _context.Projects
                .Include(d => d.Department)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Project> Add(Project project)
        {
            await _context.AddAsync(project);

            _context.SaveChanges();
            
            return project;
        }
        public Project Update(Project project)
        {
            _context.Update(project);

            _context.SaveChanges();

            return project;
        }
        public Project Delete(Project project)
        {
            _context.Remove(project);

            _context.SaveChanges();

            return project;
        } 
    }
}
