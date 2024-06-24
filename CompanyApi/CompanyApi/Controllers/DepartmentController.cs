using AutoMapper;
using CompanyApi.Dtos;
using CompanyApi.Models;
using CompanyApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServic _departmentServic;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentServic departmentServic, IMapper mapper)
        {
            _departmentServic = departmentServic;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var departments = await _departmentServic.GetAll();

            var data = _mapper.Map<IEnumerable<DepartmentsDetailsDto>>(departments);

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByDepartmentIdAsync(int id)
        {
            var department = await _departmentServic.GetById(id);

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Department department)
        {
            await _departmentServic.Add(department);

            return Ok(department);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromForm] Department department)
        {
            var dept = await _departmentServic.GetById(id);

            if (dept is null)
                return NotFound();

            //dept.Id = department.Id;
            dept.Name = department.Name;
            dept.projects = department.projects;

            _departmentServic.Update(dept);

            return Ok(department);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var department = await _departmentServic.GetById(id);

            if (department is null)
                return NotFound($"No movie was found with ID {id}");

            _departmentServic.Delete(department);

            return Ok(department);
        }
    }
}
