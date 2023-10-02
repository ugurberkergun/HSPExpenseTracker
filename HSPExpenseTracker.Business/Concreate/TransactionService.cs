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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWorkService unitOfWorkService, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<NoDataResponse>> AddTransaction(TransactionDto transactionDto)
        {
            try
            {
                if (transactionDto == null)
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    var transaction = _mapper.Map<Transaction>(transactionDto);
                    await _transactionRepository.Save(transaction);
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

        public ResponseModel<NoDataResponse> DeleteTransaction(DeleteTransactionDto transactionDto)
        {
            try
            {
                var transaction = _transactionRepository.GetFirstOrDefault(x => x.AccountGuid == transactionDto.AccountGuid && x.Id == transactionDto.TransactionId && !x.IsDeleted);
                if (transaction == null)
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    _transactionRepository.Delete(transaction);
                    _unitOfWorkService.Commit();
                    return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }
        public ResponseModel<NoDataResponse> UpdateTransaction(UpdateTransactionDto transactionDto)
        {
            try
            {
                var transaction = _transactionRepository.GetFirstOrDefault( x => x.AccountGuid == transactionDto.AccountGuid && x.Id == transactionDto.TransactionId && !x.IsDeleted);
                if (transaction == null)
                {
                    return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    transaction.Amount = transactionDto.Amount;
                    transaction.CategoryId = transactionDto.CategoryId;
                    transaction.Date = transactionDto.Date;
                    _transactionRepository.Update(transaction);
                    _unitOfWorkService.Commit();
                    return new ResponseModel<NoDataResponse>() { HasError = false, Message = Messages.SuccessfullyMesage };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<NoDataResponse>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }

        public ResponseModel<List<TransactionDto>> GetTransactionList(Guid accountGuid,DateTime? startDate = null,DateTime? endDate = null)
        {
            try
            {
                if (accountGuid == Guid.Empty)
                {
                    return new ResponseModel<List<TransactionDto>>() { HasError = true, Message = Messages.ErrorMesage };
                }
                else
                {
                    List<Transaction> transactionList = new List<Transaction>();
                    if (startDate != null && endDate != null)
                    {
                        transactionList = _transactionRepository.GetList(x => !x.IsDeleted && x.AccountGuid == accountGuid && x.Date > startDate && x.Date < endDate).ToList();
                    }
                    else
                    {
                        transactionList = _transactionRepository.GetList(x => !x.IsDeleted && x.AccountGuid == accountGuid).ToList();
                    }
                    List<TransactionDto> transactionDtos = new List<TransactionDto>();
                    foreach (var transaction in transactionList)
                    {
                        var transactionDto = _mapper.Map<TransactionDto>(transaction);
                        transactionDtos.Add(transactionDto);
                    }
                    return new ResponseModel<List<TransactionDto>>() { HasError = false, Message = Messages.SuccessfullyMesage,Data = transactionDtos };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<TransactionDto>>() { HasError = true, Message = Messages.ErrorMesage };
                throw;
            }
        }
    }
}
