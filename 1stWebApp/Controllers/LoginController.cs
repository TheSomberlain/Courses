using _1stWebApp.Entities;
using _1stWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*namespace _1stWebApp.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class LoginController : ControllerBase
        {
            private readonly SignInManager<User> _signInManager;
            private readonly UserManager<User> _userManager;
            private readonly JwtService _jwtService;

            public LoginController(SignInManager<User> signInManager,
                                   UserManager<User> userManager,
                                   JwtService jwtService)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _jwtService = jwtService;
            }

            [HttpGet("token")]
            public async Task<IActionResult> GetToken(string username, string password)
            {
                // Go To Identity
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if (!result.Succeeded)
                    return Unauthorized("User name or password isn't correct");

                var lastname = await _userManager.Users
                                                 .Where(u => u.UserName == username)
                                                 .Select(u => u.SomeProp)
                                                 .FirstAsync();

                var token = _jwtService.GetToken(username, lastname);

                return Ok(token);
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateUser([FromForm] string username,
                                                        [FromForm] string someprop,
                                                        [FromForm] string password)
            {
                var result = await _userManager.CreateAsync(new User
                {
                    UserName = username,
                    SomeProp = someprop
                },
                                                            password);

                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok(username);
            }
        }
    }
    */
