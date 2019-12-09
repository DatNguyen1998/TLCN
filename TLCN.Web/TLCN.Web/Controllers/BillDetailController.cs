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
        private readonly IAuthUserService _authUserService;
        private readonly IBillService _billService;
        private readonly IProductService _productService;
        private readonly IHostingEnvironment _host;
        public BillDetailController(IBillDetailService billDetailService, IHostingEnvironment host, IProductService productService, IAuthUserService authUserService, IBillService billService)
        {
            _billDetailService = billDetailService;
            _host = host;
            _productService = productService;
            _authUserService = authUserService;
            _billService = billService;
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

        //update status cho bill detail : truyen authUserId ==> lay Id User ==> lay 
        [HttpPost("[action]")]
        public async Task<ActionResult> UpdateStatus([FromBody] SearchViewModel model)
        {
            try
            {
                var authUser = await _authUserService.FindByIdAsync(model.AuthUserId);
                var billDetails = _billDetailService.FindToEntity(x => x.AuthUserId == authUser.Id && x.IsActivated == false);
                if (billDetails == null)
                {
                    return BadRequest("Model is not exists");
                }
                BillViewModel bill = new BillViewModel();
                bill.Id = new Guid();
                bill.Status = "Chờ Duyệt";
                bill.AuthUserId = authUser.Id;
                bill.Total = model.Total;
                bill.Created = DateTime.Now;
                //addpromotion 
                await _billService.CreateAsync(bill);
                var bill_Db = _billService.FindToEntity(x => x.AuthUserId == authUser.Id).OrderBy(a => a.Created).ToList().Last();
                foreach (var item in billDetails)
                {
                    item.IsActivated = true;
                    item.BillId = bill_Db.Id;
                    await _billDetailService.UpdateAsync(item);
                }
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

        [HttpPost("[action]")]
        public IActionResult Filter([FromBody] SearchViewModel model)
        {
            try
            {
                var detailBills = _billDetailService.Find(model, "Product,Bill,AuthUser");
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