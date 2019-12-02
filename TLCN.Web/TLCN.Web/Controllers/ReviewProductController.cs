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
    public class ReviewProductController : ControllerBase
    {
        private readonly IReviewProductService _reviewProductService;
        private readonly IHostingEnvironment _host;
        public ReviewProductController(IReviewProductService reviewProductService, IHostingEnvironment host)
        {
            _reviewProductService = reviewProductService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _reviewProductService.GetAll();
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
                var review = await _reviewProductService.FindByIdAsync(model.Id);
                return Ok(review);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] ReviewProductViewModel model)
        {
            try
            {
                await _reviewProductService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Update([FromBody] ReviewProductViewModel model)
        {
            try
            {
                var model_db = await _reviewProductService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _reviewProductService.UpdateAsync(model_db, model_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteViewModel model)
        {
            try
            {
                var mode_db = await _reviewProductService.FindByIdAsync(model.Id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _reviewProductService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}