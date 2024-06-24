using CompanyApi.Models;

namespace CompanyApi.Dtos
{
    public class DepartmentsDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> projects { get; set; } = new List<string>();
    }
}
