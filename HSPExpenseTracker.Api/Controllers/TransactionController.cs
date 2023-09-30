using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Business.Concreate;
using HSPExpenseTracker.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSPExpenseTracker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : CustomBaseController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(TransactionDto transactionDto)
        {
            return ActionResultInstance(await _transactionService.AddTransaction(transactionDto));
        }
        
        [HttpPost]
        public IActionResult DeleteTransaction(TransactionDto transactionDto)
        {
            return ActionResultInstance(_transactionService.DeleteTransaction(transactionDto));
        }   
        [HttpPut]
        public IActionResult UpdateTransaction(UpdateTransactionDto transactionDto)
        {
            return ActionResultInstance(_transactionService.UpdateTransaction(transactionDto));
        }
    }
}
