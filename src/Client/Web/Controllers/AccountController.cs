using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore21Angular.Client.Web.Controllers
{
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

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]Models.Account.RegistrationViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await userManager.CreateAsync(userIdentity, model.Password);

        //    if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

        //    await _appDbContext.JobSeekers.AddAsync(new JobSeeker { IdentityId = userIdentity.Id, Location = model.Location });
        //    await _appDbContext.SaveChangesAsync();

        //    return new OkObjectResult("Account created");
        //}


        [HttpPost]
        [AllowAnonymous]
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


        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
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
                new Claim("adr", HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<string>("Authentication:Secret")));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(this.configuration.GetValue<int>("Authentication:ExpiryTimeInDays"));

            JwtSecurityToken token = new JwtSecurityToken(
                configuration.GetValue<string>("Authentication:Issuer"),
                configuration.GetValue<string>("Authentication:Issuer"),
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public struct RegisterModel
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public struct LoginModel
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }
        #endregion
    }
}