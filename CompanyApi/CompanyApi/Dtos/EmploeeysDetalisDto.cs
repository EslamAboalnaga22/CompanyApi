using CompanyApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Dtos
{
    public class EmploeeysDetalisDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public byte[] Image { get; set; }
        public string EmpManger { get; set; }

        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
