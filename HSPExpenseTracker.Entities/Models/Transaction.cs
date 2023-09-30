using HSPExpenseTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Entities.Models
{
    public class Transaction : BaseEntity, IEntity
    {
        public double Amount { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public Guid AccountGuid { get; set; }
    }
}
