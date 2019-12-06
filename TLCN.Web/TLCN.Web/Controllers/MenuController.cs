using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.ViewModels;
using TLCN.Web.Services;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IHostingEnvironment _host;
        public MenuController(IMenuService menuService, IHostingEnvironment host)
        {
            _menuService = menuService;
            _host = host;
        }

        [HttpGet("[action]")]
        //[Authorize(Policy = "RequireLoggedIn")]
        public IActionResult GetAll()
        {
            try
            {
                var menus = _menuService.GetAll("Parent");
                var result = Mapper.Map<IEnumerable<MenuGridViewModel>>(menus);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> GetById([FromBody] SearchViewModel model)
        {
            try
            {
                var menu = await _menuService.FindByIdAsync(model.Id);
                return Ok(menu);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var menus = _menuService.Find(model, "Parent");
                var result = Mapper.Map<IEnumerable<MenuGridViewModel>>(menus);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody]MenuViewModel model)
        {
            try
            {
                model.Id = new Guid();
                await _menuService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] MenuViewModel model)
        {
            try
            {
                var model_db = await _menuService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _menuService.UpdateAsync(model_db, model_db.Id);
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
                var model_db = await _menuService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _menuService.DeleteAsync(model_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}