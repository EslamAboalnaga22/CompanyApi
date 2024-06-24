using CompanyApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Dtos
{
    public class EmployeeBaseDto
    {

        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public int? EmpMangerId { get; set; }

        // we will remove nullable after that
        public int DepartmentId { get; set; }
    }
}
