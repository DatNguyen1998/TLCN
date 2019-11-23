using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.Web.Services;
using TLCN.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IHostingEnvironment _host;
        public CartController(ICartService cartService, IHostingEnvironment host)
        {
            _cartService = cartService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var carts = _cartService.GetAll();
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CartViewModel model)
        {
            try
            {
                await _cartService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update([FromBody] CartViewModel model)
        {
            try
            {
                var model_db = await _cartService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _cartService.UpdateAsync(model_db, model_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromForm] Guid id)
        {
            try
            {
                var mode_db = await _cartService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _cartService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}