using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult GetAll()
        {
            try
            {
                var authUsers = _authUserService.GetAll("Gender,Province,District");
                var result = Mapper.Map<IEnumerable<AuthUserGetGridViewModel>>(authUsers);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> GetById([FromBody] SearchViewModel model)
        {
            try
            {
                var authUser = await _authUserService.FindByIdAsync(model.Id);
                return Ok(authUser);
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
                //Hash Pass
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password, salt);

                model.Id = new Guid();
                await _authUserService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
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

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Delete([FromBody] DeleteViewModel model)
        {
            try
            {
                var mode_db = await _authUserService.FindByIdAsync(model.Id);
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
                            new Claim("role", user.Role),
                            new Claim("LoggedOn", DateTime.Now.ToString()),

                        }),

                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                        Issuer = _appSetting.Site,
                        Audience = _appSetting.Audience,
                        Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                    };
                    var jwtTokenHandler = new JwtSecurityTokenHandler();
                    var token = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                    return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, username = user.Username, role = user.Role, userId = user.Id, name = user.Fullname});
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var authUsers = _authUserService.Find(model, "Gender,Province,District");
                var result = Mapper.Map<IEnumerable<AuthUserGetGridViewModel>>(authUsers);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}