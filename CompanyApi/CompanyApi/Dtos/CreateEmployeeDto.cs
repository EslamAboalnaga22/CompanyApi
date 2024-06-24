namespace CompanyApi.Dtos
{
    public class CreateEmployeeDto : EmployeeBaseDto
    {
        public IFormFile Photo { get; set; }
    }
}
