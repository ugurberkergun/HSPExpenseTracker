using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Dtos
{
    public class DeleteTransactionDto
    {
        public long TransactionId { get; set; }
        public Guid AccountGuid { get; set; }
    }
}
