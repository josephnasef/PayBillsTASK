using PayBills.Domin.Context;
using PayBills.Domin.Models;
using PayBills.Repository.Abstraction;
using PayBills.Repository.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Repository.Mangers
{
    public class BillRepo : Repository<Bill>,IBillRepo
    {
        public BillRepo(PayBillContext BloggerContext) : base(BloggerContext)
        {
        }
    }
}
