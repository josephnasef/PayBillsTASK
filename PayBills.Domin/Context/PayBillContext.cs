using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayBills.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Domin.Context
{
    public class PayBillContext : IdentityDbContext
    {
        public PayBillContext(DbContextOptions<PayBillContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Bill> Bill { get; set; }
    }
}
