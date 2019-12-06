using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IProductService _productService;
        private readonly IHostingEnvironment _host;
        public BillDetailController(IBillDetailService billDetailService, IHostingEnvironment host, IProductService productService)
        {
            _billDetailService = billDetailService;
            _host = host;
            _productService = productService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var billDetails = _billDetailService.GetAll("Product,Bill,AuthUser");
                var result = Mapper.Map<IEnumerable<BillDetailForClientViewModel>>(billDetails);
                return Ok(result);
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
                model.Id = new Guid();
                //lay price cua product 
                var product = await _productService.FindByIdAsync(model.ProductId);
                model.PriceTotal = model.Amount * product.Price;
                await _billDetailService.CreateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("[action]")]
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
                var product = await _productService.FindByIdAsync(model.ProductId);
                model_db.PriceTotal = model.Amount * product.Price;
                await _billDetailService.UpdateAsync(model_db, model_db.Id);
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
                var mode_db = await _billDetailService.FindByIdAsync(model.Id);
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

        [HttpPost("[action]")]
        public IActionResult GetProductForClient([FromBody] BillDetailViewModel model)
        {
            try
            {
                var detailBills = _billDetailService.GetCartForAuthUser(model.AuthUserId, "Product,Bill,AuthUser");
                var result = Mapper.Map<IEnumerable<BillDetailForClientViewModel>>(detailBills);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}