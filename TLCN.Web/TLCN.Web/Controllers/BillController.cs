using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.Web.Services;
using TLCN.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IHostingEnvironment _host;
        public BillController(IBillService billService, IHostingEnvironment host)
        {
            _billService = billService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var bills = _billService.GetAll("AuthUser,Promotions");
                var result = Mapper.Map<IEnumerable<BillForGridViewModel>>(bills);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] BillViewModel model)
        {
            try
            {
                model.Id = new Guid();
                model.Status = "Chờ Duyệt";
                await _billService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<ActionResult> Update([FromBody] BiLLUpdateViewModel model)
        {
            try
            {
                var model_db = await _billService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db.Status = model.Status;
                await _billService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _billService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _billService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var detailBills = _billService.Find(model, "AuthUser,Promotions");
                var result = Mapper.Map<IEnumerable<BillForGridViewModel>>(detailBills);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}