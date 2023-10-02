using AutoMapper;
using HSPExpenseTracker.Entities.Dtos;
using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Account, CreateAccountDto > ().ReverseMap();
            CreateMap<Account, AccountDetailDto>().ReverseMap();
        }
    }
}
