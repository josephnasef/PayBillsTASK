using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayBills.DTO.DTOs;
using PayBills.Services.Abstraction;
using PayBills.Services.Services;
using System;
using System.Threading.Tasks;

namespace PayBills.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        [HttpPost("CreateBill")]
        public async Task<IActionResult> CreateBill(BillDTO billDTO)
        {
            var result = await _billService.AddAsync(billDTO);
            return Ok(new { Num = result.Id , State = "Genrated", Amount = result.Amount , GeratedDate = DateTime.Now });
        }
        [HttpPut("UpdateBill")]
        public async Task<IActionResult> UpdateBill(int Id , BillDTO billDTO)
        {
            var result = await _billService.UpdateAsync(Id , billDTO);
            return Ok(new { Num = result.Id, State = "Updated", Amount = result.Amount, GeratedDate = DateTime.Now });
        }
        [HttpPost("RefundBill")]
        public async Task<IActionResult> RefundBill(int Id)
        {
            var result = await _billService.RefundBill(Id );
            return Ok(new { Num = result.Id, State = "Refunded", Amount = result.Amount, GeratedDate = DateTime.Now });
        }
    }
}
