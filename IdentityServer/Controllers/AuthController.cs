using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IIdentityServerInteractionService interaction)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
        }

        [HttpPost]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("reg")]
        public async Task<IdentityResult> Register()
        {
            var valami = await _userManager.CreateAsync(new zhunting.Data.Models.User { UserName = "Mark" }, "Pass123@");
            if (valami.Succeeded)
            {
                return valami;
            }
            else
            {
                return valami;
            }
        }
    }
}
