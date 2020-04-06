using System.Threading.Tasks;
using _1stWebApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1stWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> um, SignInManager<User> signInManager)
        {
            _userManager = um;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] string name, 
                                                  [FromForm] string lastName,
                                                   [FromForm] string password)
        {
            var user = new User() {UserName = name, LastName = lastName};
            var result  =await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(409); ;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string name, [FromForm] string password)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user != null)
            {
                var res =await _signInManager.PasswordSignInAsync(user, password, false,false);
                if (res.Succeeded)
                {
                    return Ok();
                }
            }
            return StatusCode(409);
        }

    }
}
