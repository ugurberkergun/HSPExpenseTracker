using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Dtos
{
    public class UpdateTransactionDto
    {
        public long TransactionId { get; set; }
        public double Amount { get; set; }
        public long CategoryId { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountGuid { get; set; }
    }
}
