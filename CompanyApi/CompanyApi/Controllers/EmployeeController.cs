using AutoMapper;
using CompanyApi.Dtos;
using CompanyApi.Models;
using CompanyApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentServic _departmentService;
        private readonly IMapper _mapper;
        private new List<String> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IDepartmentServic departmentService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAll();

            var data = _mapper.Map<IEnumerable<EmploeeysDetalisDto>>(employees);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByEmployeeIdAsync(int id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee is null)
                return NotFound();

            var data = _mapper.Map<EmploeeysDetalisDto>(employee);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]CreateEmployeeDto dto)
        {
            if(!_allowedExtenstions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if(dto.Photo.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB");

            var isValidDept = await _departmentService.isValidDepartment(dto.DepartmentId);

            if (!isValidDept)
            {
                return BadRequest("Invalid DepartmentId");
            };

            using var dataStream = new MemoryStream();
            await dto.Photo.CopyToAsync(dataStream);

            var employee = _mapper.Map<Employee>(dto);
            employee.Image = dataStream.ToArray();

            _employeeService.Add(employee);

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromForm]UpdateEmployeeDto dto)
        {
            var employee = await _employeeService.GetById(id);
            
            if (employee is null)
                return NotFound();

            var isValidDept = await _departmentService.isValidDepartment(dto.DepartmentId);

            if (!isValidDept)
            {
                return BadRequest("Invalid DepartmentId");
            };

            if (dto.Photo is not null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Photo.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (dto.Photo.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB");


                using var dataStream = new MemoryStream();
                await dto.Photo.CopyToAsync(dataStream);

                employee.Image = dataStream.ToArray();
            }

            employee.Name = dto.Name;
            employee.BirthDate = dto.BirthDate;
            employee.Gender = dto.Gender;
            employee.DepartmentId = dto.DepartmentId;
            employee.EmpMangerId = dto.EmpMangerId;

            _employeeService.Update(employee);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var employee = await _employeeService.GetById(id);

            if(employee is null)
                return NotFound($"No movie was found with ID {id}");

            _employeeService.Delete(employee);

            return Ok(employee);
        }
    }
}
