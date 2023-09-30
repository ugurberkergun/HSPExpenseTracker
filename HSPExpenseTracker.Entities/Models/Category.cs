using HSPExpenseTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Models
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
