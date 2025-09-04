using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controller
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<ApplicationUser> userManager) : ControllerBase
    {
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await userManager.FindByIdAsync(
                (User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value) ?? string.Empty);
            return Ok(new
            {
                Id = user?.Id,
                Name = user?.Name,
                Surname = user?.Surname,
                Email = user?.Email,
                Username = user?.UserName
            });
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userManager.Users.Select(user => new GetAllUsersDto
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Id = user.Id,
                Username = user.UserName
            }).ToListAsync());
        }
    }
}