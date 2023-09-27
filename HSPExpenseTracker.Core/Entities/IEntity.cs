using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Core.Entities
{
    public interface IEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
