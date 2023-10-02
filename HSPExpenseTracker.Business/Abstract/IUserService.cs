using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Business.Abstract
{
    public interface IUserService
    {
        Task<ResponseModel<NoDataResponse>> AddNewUser(UserDto user);
    }
}
