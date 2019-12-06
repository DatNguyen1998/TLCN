using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.Common.Dto;
using TLCN.ViewModels;
using TLCN.Web.Services;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMenuService _menuService;
        private readonly IHostingEnvironment _host;
        private readonly string url = "../Images/";
        public ProductController(IProductService productService, IHostingEnvironment host, IMenuService menuService)
        {
            _productService = productService;
            _host = host;
            _menuService = menuService;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productService.GetAll("Menu,Producer");
                var result = Mapper.Map<IEnumerable<ProductGridViewModel>>(products);
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
                var product = await _productService.FindByIdAsync(model.Id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireLoggedIn")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var products = _productService.Find(model, "Menu,Producer");
                var result = Mapper.Map<IEnumerable<ProductGridViewModel>>(products);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody] ProductViewModel model)
        {
            try
            {
                model.Id = new Guid();
                model.LogoId = url + model.LogoId;
                await _productService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] ProductViewModel model)
        {
            try
            {
                var model_db = await _productService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                model_db.LogoId = url + model_db.LogoId;
                await _productService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _productService.FindByIdAsync(model.Id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _productService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Client 
        //
        [HttpPost("[action]")]
        public IActionResult GetProductForClient([FromBody] ProductMenuIdViewModel model)
        {
            try
            {
                var menu = _menuService.FindToEntity(x => x.Code == model.MenuCode).FirstOrDefault();
                var products = _productService.GetProductForClient(menu.Id, "Menu,Producer");
                var result = Mapper.Map<IEnumerable<ProductGridViewModel>>(products);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}