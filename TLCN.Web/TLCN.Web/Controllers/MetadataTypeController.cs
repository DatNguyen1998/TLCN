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
    public class MetadataTypeController : ControllerBase
    {
        private readonly IMetadataTypeService _metadataTypeService;
        private readonly IHostingEnvironment _host;
        public MetadataTypeController(IMetadataTypeService metadataTypeService, IHostingEnvironment host)
        {
            _metadataTypeService = metadataTypeService;
            _host = host;
        }


        [HttpGet("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public IActionResult GetAll()
        {
            try
            {
                var metadataTypes = _metadataTypeService.GetAll();
                return Ok(metadataTypes);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody] MetadataTypeViewModel model)
        {
            try
            {
                model.IsActivated = true;
                await _metadataTypeService.CreateAsync(model);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Update([FromBody] MetadataTypeViewModel model)
        {
            try
            {
                var model_db = await _metadataTypeService.FindByIdAsync(model.Id);
                if(model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                model_db = model;
                await _metadataTypeService.UpdateAsync(model_db, model_db.Id);
                return Ok();
            }
            catch(Exception e)
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
                var mode_db = await _metadataTypeService.FindByIdAsync(id);
                if(mode_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _metadataTypeService.DeleteAsync(mode_db.Id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}