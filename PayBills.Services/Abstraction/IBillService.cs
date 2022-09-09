using PayBills.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Services.Abstraction
{
    public interface IBillService
    {
        Task<BillDTO> AddAsync(BillDTO entity);      
        Task<bool> RemoveByIdAsync(params object[] Id);
        Task<BillDTO> UpdateAsync(int Id, BillDTO entity);
        Task<BillDTO> RefundBill(int Id);


    }
}
