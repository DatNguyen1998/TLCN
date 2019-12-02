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
        //[Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> GetById([FromBody] SearchViewModel model)
        {
            try
            {
                var promotion = await _promotionService.FindByIdAsync(model.Id);
                return Ok(promotion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody] PromotionViewModel model)
        {
            try
            {
                model.Id = new Guid();
                await _promotionService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
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

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Delete([FromBody] DeleteViewModel model)
        {
            try
            {
                var mode_db = await _promotionService.FindByIdAsync(model.Id);
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

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var promotions = _promotionService.Find(model);
                var result = Mapper.Map<IEnumerable<PromotionViewModel>>(promotions);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}