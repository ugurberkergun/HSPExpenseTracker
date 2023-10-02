using HSPExpenseTracker.Business.Abstract;
using HSPExpenseTracker.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSPExpenseTracker.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserDto userDto)
        {
            return ActionResultInstance(await _userService.AddNewUser(userDto));
        }
    }
}
