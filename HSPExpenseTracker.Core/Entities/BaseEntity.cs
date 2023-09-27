using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Core.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
