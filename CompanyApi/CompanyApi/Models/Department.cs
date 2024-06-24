using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project>? projects { get; set; } =new List<Project>();
    }
}
