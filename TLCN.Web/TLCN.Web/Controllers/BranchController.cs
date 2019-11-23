using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCN.Web.Services;
using TLCN.ViewModels;

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly IHostingEnvironment _host;
        public BranchController(IBranchService branchService, IHostingEnvironment host)
        {
            _branchService = branchService;
            _host = host;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var branchs = _branchService.GetAll();
                return Ok(branchs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] BranchViewModel  model)
        {
            try
            {
                await _branchService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> Update([FromBody] BranchViewModel model)
        {
            try
            {
                var model_db = await _branchService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _branchService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _branchService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _branchService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}