using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Dtos
{
    public class CreateAccountDto
    {
        public long UserId { get; set; }
        public string AccountName { get; set; }
        public Guid AccountGuid { get; set; } = new Guid();
    }
}
