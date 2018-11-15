using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetCore21Angular.Client.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore21Angular.Client.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        private readonly IConfiguration configuration;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]RegisterModel model)
        {
            IdentityUser identityUser = new IdentityUser() { Email = model.Email, UserName = model.Email };

            IdentityResult result = await userManager.CreateAsync(identityUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.ToString());
            }

            IdentityUser user = await userManager.FindByEmailAsync(model.Email);

            await LoginUser(user, model.Password, false);

            return Ok(GenerateJwtToken(model.Email, user));
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginModel model)
        {
            IdentityUser user = await userManager.FindByEmailAsync(model.Email);
            Microsoft.AspNetCore.Identity.SignInResult result = await LoginUser(user, model.Password, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return BadRequest("LockedOut");
                }
                return BadRequest("WrongUserOrPassword");
            }

            return Ok(GenerateJwtToken(model.Email, user));
        }

        #region Helpers
        private async Task<Microsoft.AspNetCore.Identity.SignInResult> LoginUser(IdentityUser user, string password, bool lockout)
        {
            return await signInManager.CheckPasswordSignInAsync(user, password, lockout);
        }

        private async Task LogoutUser()
        {
            await signInManager.SignOutAsync();
            return;
        }

        private string GenerateJwtToken(string email, IdentityUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<string>("Authentication:Secret")));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("Authentication:Issuer"),
                audience: configuration.GetValue<string>("Authentication:Issuer"),
                claims: claims,
                expires: DateTime.Now.AddDays(this.configuration.GetValue<int>("Authentication:ExpiryTimeInDays")),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}