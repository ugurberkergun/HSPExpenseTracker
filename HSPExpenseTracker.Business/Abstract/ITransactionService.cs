﻿using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSPExpenseTracker.Business.Abstract
{
    public interface ITransactionService
    {
        Task<ResponseModel<NoDataResponse>> AddTransaction(TransactionDto transactionDto);
        ResponseModel<List<TransactionDto>> GetTransactionList(Guid accountGuid,DateTime? startDate = null, DateTime? endDate = null);
        ResponseModel<NoDataResponse> DeleteTransaction(DeleteTransactionDto transactionDto);
        ResponseModel<NoDataResponse> UpdateTransaction(UpdateTransactionDto transactionDto);
    }
}
