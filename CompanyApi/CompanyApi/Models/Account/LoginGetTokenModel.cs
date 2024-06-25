using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Models.Account
{
    public class LoginGetTokenModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
