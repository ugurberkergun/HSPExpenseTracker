using HSPExpenseTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Models
{
    public class Account:BaseEntity,IEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public Guid AccountGuid { get; set; }

    }
}
