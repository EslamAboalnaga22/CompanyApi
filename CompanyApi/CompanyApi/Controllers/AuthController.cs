using CompanyApi.Models.Account;
using CompanyApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public AuthController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authServices.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody] LoginGetTokenModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authServices.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookies(result.RefreshToken, result.RefreshtokenExpiration);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authServices.AddRoleAsync(model);

            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(result);
        }

        //add refresh token with cookies
        private void SetRefreshTokenInCookies(string refreshToken, DateTime expires)
        {
            var cookiesOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime()
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookiesOption);
        }
    }
}
