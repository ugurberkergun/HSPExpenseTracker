using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Core.Utilities.Results;
using HSPExpenseTracker.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSPExpenseTracker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class AccountController : CustomBaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto accountDto)
        {
            return ActionResultInstance(await _accountService.CreateAccountAsync(accountDto));
        }
        [HttpPut]
        public IActionResult DeleteAccount(AccountDto accountDto)
        {
            return ActionResultInstance(_accountService.DeleteAccount(accountDto));
        }
        [HttpPut]
        public IActionResult UpdateAccount(AccountDto accountDto)
        {
            return ActionResultInstance(_accountService.UpdateAccount(accountDto));
        }
        [HttpGet]
        public IActionResult GetAccountListForUser(long userId)
        {
            return ActionResultInstance(_accountService.GetAccountListForUser(userId));
        }
        [HttpGet]
        public IActionResult GetAccountsTransactionsAndDetails(Guid accountsGuid)
        {
            return ActionResultInstance(_accountService.GetAccountDetail(accountsGuid));
        }
    }
}
