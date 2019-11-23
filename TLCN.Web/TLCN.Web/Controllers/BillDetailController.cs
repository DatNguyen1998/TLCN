using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.ViewModels;
using TLCN.Web.Services;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private readonly IBillDetailService _billDetailService;
        private readonly IHostingEnvironment _host;
        public BillDetailController(IBillDetailService billDetailService, IHostingEnvironment host)
        {
            _billDetailService = billDetailService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var billDetails = _billDetailService.GetAll();
                return Ok(billDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] BillDetailViewModel model)
        {
            try
            {
                await _billDetailService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update([FromBody] BillDetailViewModel model)
        {
            try
            {
                var model_db = await _billDetailService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _billDetailService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _billDetailService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _billDetailService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}