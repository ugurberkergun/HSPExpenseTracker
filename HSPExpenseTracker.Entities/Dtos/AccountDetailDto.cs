using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Dtos
{
    public class AccountDetailDto
    {
        public double Balance { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
