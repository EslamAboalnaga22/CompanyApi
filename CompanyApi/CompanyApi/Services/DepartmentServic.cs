using CompanyApi.Data;
using CompanyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services
{
    public class DepartmentServic : IDepartmentServic
    {
        private readonly AppDbContext _context;

        public DepartmentServic(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments
                .Include(p => p.projects)
                //.ThenInclude(n => n.Name)
                .ToListAsync();
        }
        public async Task<Department> GetById(int id)
        {
            return await _context.Departments
                .Include(p => p.projects)
                .SingleOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Department> Add(Department department)
        {
            await _context.AddAsync(department);
            _context.SaveChanges();

            return department;
        } 

        public Department Update(Department department)
        {
            _context.Update(department);
            _context.SaveChanges();

            return department;
        }
        public Department Delete(Department department)
        {
            _context.Remove(department);
            _context.SaveChanges();

            return department;
        }
        public Task<bool> isValidDepartment(int id)
        {
            return _context.Departments.AnyAsync(e => e.Id == id);
        }


    }
}
