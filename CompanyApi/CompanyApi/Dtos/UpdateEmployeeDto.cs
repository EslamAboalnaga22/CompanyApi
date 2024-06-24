namespace CompanyApi.Dtos
{
    public class UpdateEmployeeDto : EmployeeBaseDto
    {
        public IFormFile? Photo { get; set; }
    }
}
