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

namespace TLCN.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataValueController : ControllerBase
    {
        private readonly IMetadataValueService _metadataValueService;
        private readonly IHostingEnvironment _host;
        public MetadataValueController(IMetadataValueService metadataValueService, IHostingEnvironment host)
        {
            _metadataValueService = metadataValueService;
            _host = host;
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult GetAll()
        {
            try
            {
                var metadataValues = _metadataValueService.GetAll();
                return Ok(metadataValues);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody]MetadataValueViewModel  model)
        {
            try
            {
                model.IsActivated = true;
                await _metadataValueService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] MetadataValueViewModel model)
        {
            try
            {
                var model_db = await _metadataValueService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _metadataValueService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _metadataValueService.FindByIdAsync(id);
                if (mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _metadataValueService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}