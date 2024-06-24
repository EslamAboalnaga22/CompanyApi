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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IDepartmentServic _departmentService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper, IDepartmentServic departmentService)
        {
            _projectService = projectService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var projects = await _projectService.GetAll();

            var data = _mapper.Map<IEnumerable<ProjectsDetalisDto>>(projects);
            
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByProjectIdAsync(int id)
        {
            var project = await _projectService.GetById(id);

            if(project is null) 
                return NotFound($"Not Exist {id}");
            
            var data = _mapper.Map<ProjectsDetalisDto>(project);

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] Project project)
        {
            var isValidDept = await _departmentService.isValidDepartment(project.DepartmentId);

            if (!isValidDept)
            {
                return BadRequest("Invalid DepartmentId");
            };

            await _projectService.Add(project);

            return Ok(project);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Project project)
        {
            var proj = await _projectService.GetById(id);
            if (proj is null)
                return NotFound($"Not Exist");

            var isValidDept = await _departmentService.isValidDepartment(project.DepartmentId);

            if (!isValidDept)
            {
                return BadRequest("Invalid DepartmentId");
            };

            //project.Id = proj.Id;
            proj.Name = project.Name;
            proj.City = project.City;
            proj.DepartmentId = project.DepartmentId;

            _projectService.Update(proj);

            return Ok(proj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var project = await _projectService.GetById(id);

            if (project is null)
                return NotFound($"Not Exist {id}");

            _projectService.Delete(project);

            return Ok(project);
        }

    }
}
