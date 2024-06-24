using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

    }
}
