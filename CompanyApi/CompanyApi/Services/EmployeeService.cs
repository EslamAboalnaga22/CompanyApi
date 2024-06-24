using CompanyApi.Data;
using CompanyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees
                .Include(d => d.Department)
                .ToListAsync();
        }
        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees
                .Include(d => d.Department)
                .SingleOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Employee> Add(Employee employee)
        {
             await _context.AddAsync(employee);
            _context.SaveChanges();

            return employee;
        }
        public Employee Update(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();

            return employee;
        }
        public Employee Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();

            return employee;
        }

        
    }
}
