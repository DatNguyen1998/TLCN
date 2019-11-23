using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly IHostingEnvironment _host;
        public PromotionController(IPromotionService promotionService, IHostingEnvironment host)
        {
            _promotionService = promotionService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _promotionService.GetAll();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody] PromotionViewModel model)
        {
            try
            {
                await _promotionService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] PromotionViewModel model)
        {
            try
            {
                var model_db = await _promotionService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _promotionService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _promotionService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _promotionService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}