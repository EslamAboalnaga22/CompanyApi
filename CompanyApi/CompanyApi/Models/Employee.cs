using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(50) , MinLength(3)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public byte[] Image { get; set; }

        [ForeignKey("Employee")]
        public int? EmpMangerId { get; set; }
        //public Employee? EmpManger { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }

    public enum Gender
    {
        male =1,female =2
    }
}
