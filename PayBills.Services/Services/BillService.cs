using PayBills.Domin.AllEnum;
using PayBills.Domin.Models;
using PayBills.DTO.DTOs;
using PayBills.Repository.Abstraction;
using PayBills.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Services.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepo _billRepo;
        public BillService(IBillRepo billRepo)
        {
            _billRepo = billRepo;
        }
        public async Task<BillDTO> AddAsync(BillDTO entity)
        {
            Bill bill = new Bill()
            {
                Amount = entity.Amount,
                CreatedBy = "Test",
                Isapproved = true,
                isDeleted = false,
                LastEditeBy = "Test",
                LastEiteDate = DateTime.Now,
                state = (int)BillState.Reserved
            };
            var result = await _billRepo.AddAsync(bill);
            if (result!=null)
            {
                BillDTO billDto = new BillDTO()
                {
                    Amount = result.Amount,
                   Id = result.Id
                };

                return billDto;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> RemoveByIdAsync(params object[] Id)
        {
            var result = await _billRepo.RemoveByIdAsync(Id);
            if (result != null)
            {
                return true;
            }
            return false;
        }
        public async Task<BillDTO> UpdateAsync(int Id, BillDTO entity)
        {
            Bill bill = await _billRepo.GetByAsync(Id);
            bill.Amount = entity.Amount;
            bill.LastEditeBy = "Test 2";
            bill.LastEiteDate = DateTime.Now;
            var result = await _billRepo.UpdateAsync(bill);
            if (result != null)
            {
                BillDTO billDto = new BillDTO()
                {
                    Amount = result.Amount,
                    Id = result.Id
                };

                return billDto;
            }
            else
            {
                return null;
            }
        }
        public async Task<BillDTO> RefundBill(int Id)
        {
            Bill bill = await _billRepo.GetByAsync(Id);
            bill.state = (int)BillState.Refund;
            var result = await _billRepo.UpdateAsync(bill);
            if (result != null)
            {
                BillDTO billDto = new BillDTO()
                {
                    Amount = result.Amount,
                    Id = result.Id
                };
                return billDto;
            }
            else
            {
                return null;
            }
        }       
    }
}
