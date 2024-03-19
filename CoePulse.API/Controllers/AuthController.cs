using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IIdentityRepository _identityRepository;

        public AuthController(UserManager<IdentityUser> userManager,IIdentityRepository identityRepository)
        {
            _userManager = userManager;
            _identityRepository = identityRepository;
        }

        //Post: {apibaseUrl}/api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO request)
        {
            //create identity user
            var user = new IdentityUser
            {
                UserName = request.UserName?.Trim(),
                Email = request.UserName?.Trim()
            };

            //create user
            var result = await _userManager.CreateAsync(user, request?.Password!);
            if (result.Succeeded)
            {
                //add user to role(reader)
                var identityUser = await _userManager.AddToRoleAsync(user, "Reader");
                if (identityUser.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var error in identityUser.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return ValidationProblem(ModelState);

        }

        //POST: {apibaseUrl}/api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request?.UserName ?? "");
            if (user is not null)
            {
                var result = await _userManager.CheckPasswordAsync(user, request?.Password ?? "");
                if (result)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = _identityRepository.CreateJwtToken(user, [.. roles]);
                    var resultResponse = new LoginResponseDTO
                    {
                        Roles = roles.ToList(),
                        Email = user.Email,
                        Token = token
                    };
                    return Ok(resultResponse);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid password");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username");
            }

            return ValidationProblem(ModelState);
        }

    }
}
