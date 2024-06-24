using CompanyApi.Models;

namespace CompanyApi.Dtos
{
    public class ProjectsDetalisDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
