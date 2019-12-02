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
        //[Authorize(Policy = "RequireAdministrator")]
        public IActionResult GetAll()
        {
            try
            {
                var metadataValues = _metadataValueService.GetAll("Type");
                var result = Mapper.Map<IEnumerable<MetadataValueGetGridViewModel>>(metadataValues);
                return Ok(result);
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
                var metadataValue = await _metadataValueService.FindByIdAsync(model.Id);
                return Ok(metadataValue);
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
                var metadataValues =  _metadataValueService.Find(model,"Type");
                var result = Mapper.Map<IEnumerable<MetadataValueGetGridViewModel>>(metadataValues);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
        public async Task<IActionResult> Add([FromBody]MetadataValueViewModel  model)
        {
            try
            {
                model.Id = new Guid();
                model.IsActivated = true;
                await _metadataValueService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
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

        [HttpPost("[action]")]
        //[Authorize(Policy = "RequireAdministrator")]
        public async Task<ActionResult> Delete([FromBody] DeleteViewModel model)
        {
            try
            {
                var model_db = await _metadataValueService.FindByIdAsync(model.Id);
                if (model_db == null)
                {
                    return BadRequest("Model is not exists");
                }
                await _metadataValueService.DeleteAsync(model_db.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}