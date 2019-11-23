using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TLCN.Common.Enum;
using TLCN.ViewModels;
using TLCN.Web.Services;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthUserService _authUserService;
        private readonly IHostingEnvironment _host;
        private readonly AppSetting _appSetting;
        public AuthUserController(IAuthUserService authUserService, IHostingEnvironment host, IOptions<AppSetting> appSetting)
        {
            _authUserService = authUserService;
            _host = host;
            _appSetting = appSetting.Value;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult GetAll()
        {
            try
            {
                var authUsers = _authUserService.GetAll();
                return Ok(authUsers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody] AuthUserViewModel model)
        {
            try
            {
                await _authUserService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] AuthUserViewModel model)
        {
            try
            {
                var model_db = await _authUserService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _authUserService.UpdateAsync(model_db, model_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Delete([FromForm] Guid id)
        {
            try
            {
                var mode_db = await _authUserService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _authUserService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var user = await _authUserService.GetUserByUsernameAndPassword(model.Username, model.Password);
                if(user == null)
                {
                    return BadRequest("Login in fail");
                }
                else
                {
                    var listRole = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();
                    string userRole = listRole.FirstOrDefault(x => (int)x == user.Role).ToString();
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSetting.Secrect));
                    double tokenExpiryTime = Convert.ToDouble(_appSetting.ExpireTime);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                       {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Fullname),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim("User_id", Convert.ToString(user.Id)),
                            new Claim("Username", user.Username),
                            new Claim("Role", userRole),
                            new Claim("LoggedOn", DateTime.Now.ToString()),

                        }),

                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                        Issuer = _appSetting.Site,
                        Audience = _appSetting.Audience,
                        Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                    };
                    var jwtTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                    return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, username = user.Username, role = userRole, userId = user.Id, name = user.Fullname});
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}