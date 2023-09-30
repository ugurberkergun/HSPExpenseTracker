using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Dtos
{
    public class AccountDto
    {
        public long UserId { get; set; }
        public Guid AccountGuid { get; set; }
        public string AccountName { get; set; }
    }
}
