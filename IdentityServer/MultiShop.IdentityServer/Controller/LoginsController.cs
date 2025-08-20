using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController(SignInManager<ApplicationUser> signInManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return (await signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false))
                .Succeeded
                    ? Ok("Login success")
                    : BadRequest("Login failed");
        }
    }
}