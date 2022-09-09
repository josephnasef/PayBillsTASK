using PayBills.Domin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBills.Domin.Models
{
    public class Bill: BasicsInfo
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

    }
}
