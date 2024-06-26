using System.Text.Json.Serialization;

namespace CompanyApi.Models.Account
{
    public class AuthModel
    {
        public string Message { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
        //public DateTime ExmpireOn { get; set; }

        // For Refresh Tokens
        [JsonIgnore]
        public string? RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshtokenExpiration { get; set; }
    }
}
