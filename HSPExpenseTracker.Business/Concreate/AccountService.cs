using AutoMapper;
using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Core.Constants;
using HSPExpenseTracker.Core.DAL.UnitOfWork;
using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.DAL.Abstract;
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
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWorkService unitOfWorkService, IAccountRepository accountRepository, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _accountRepository = accountRepository;
            _mapper = mapper;
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
    }
}
