namespace CompanyApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
