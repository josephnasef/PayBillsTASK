using PayBills.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Repository.Abstraction
{
    public interface IBillRepo
    {
        Task<Bill> AddAsync(Bill entity);
        Task<Bill> GetByAsync(params object[] Id);
        Bill Update(Bill entity);
        Bill Remove(Bill entity);
        Task<Bill> RemoveByIdAsync(params object[] Id);
        Task<Bill> UpdateAsync(Bill entity);
        Bill RemoveById(params object[] Id);
    }
}
