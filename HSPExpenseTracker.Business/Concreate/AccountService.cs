using AutoMapper;
using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Core.Constants;
using HSPExpenseTracker.Core.DAL.UnitOfWork;
using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.DAL.Abstract;
using HSPExpenseTracker.DAL.Concreate.Repositories;
using HSPExpenseTracker.Entities.Dtos;
using HSPExpenseTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Business.Concreate
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWorkService unitOfWorkService, IAccountRepository accountRepository, IMapper mapper, ITransactionService transactionService)
        {
            _unitOfWorkService = unitOfWorkService;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _transactionService = transactionService;
        }

        public async Task<ResponseModel<NoDataResponse>> CreateAccountAsync(CreateAccountDto accountDto)
        {
            try
            {
                if (accountDto == null)
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    // userService ile user kontrolü yap
                    var account = _mapper.Map<Account>(accountDto);
                    await _accountRepository.Save(account);
                    await _unitOfWorkService.CommitAsync();
                    return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }

        public ResponseModel<NoDataResponse> DeleteAccount(AccountDto accountDto)
        {
            try
            {
                var deletedAccount = _accountRepository.GetFirstOrDefault(x => x.UserId == accountDto.UserId && x.AccountGuid == accountDto.AccountGuid && !x.IsDeleted);
                if (deletedAccount is not null)
                {
                    _accountRepository.Delete(deletedAccount);
                    _unitOfWorkService.Commit();
                    return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };
                }
                else
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }
        public ResponseModel<NoDataResponse> UpdateAccount(AccountDto accountDto)
        {
            try
            {
                var updatedAccount = _accountRepository.GetFirstOrDefault(x => x.UserId == accountDto.UserId && x.AccountGuid == accountDto.AccountGuid && !x.IsDeleted);
                if (updatedAccount is not null)
                {
                    updatedAccount.AccountName = accountDto.AccountName;
                    _accountRepository.Update(updatedAccount);
                    _unitOfWorkService.Commit();
                    return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };
                }
                else
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }

        public ResponseModel<List<AccountDto>> GetAccountListForUser(long userId)
        {
            try
            {
                if (userId == null)
                {
                    return new ResponseModel<List<AccountDto>>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    var usersAccountList = _accountRepository.GetList(x => x.UserId == userId && !x.IsDeleted).ToList();
                    List<AccountDto> accountDtos = new List<AccountDto>();
                    foreach (var account in usersAccountList)
                    {
                        var accountDto = _mapper.Map<AccountDto>(account);
                        accountDtos.Add(accountDto);
                    }
                    return new ResponseModel<List<AccountDto>>() { HasError = false, Data = accountDtos, Message = Messages.SuccessfullyMesage };
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel<List<AccountDto>>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }

        public ResponseModel<AccountDetailDto> GetAccountDetail(Guid accountGuid)
        {
            try
            {
                var transactionList = _transactionService.GetTransactionList(accountGuid);
                if (transactionList.HasError)
                {
                    return new ResponseModel<AccountDetailDto>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    var balance = GetBalance(transactionList.Data);
                    AccountDetailDto accountDetailDto = new()
                    {
                        Balance = balance,
                        Transactions = transactionList.Data
                    };
                    return new ResponseModel<AccountDetailDto>() { HasError = false,Data = accountDetailDto, Message = Messages.SuccessfullyMesage };
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private double GetBalance(List<TransactionDto> transactionDtos)
        {
            if (transactionDtos is not null)
            {
                var balance = transactionDtos.Sum(x => x.Amount);
                return balance;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
