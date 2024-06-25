using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Models.Account
{
    public class RegisterModel
    {
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [StringLength(100), DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [StringLength(100), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
