using HSPExpenseTracker.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HSPExpenseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(ResponseModel<T> response) where T : class
        {
            if (!response.HasError)
            {
                return new ObjectResult(response)
                {
                    StatusCode = 200
                };
            }
            else
            {
                return new ObjectResult(response)
                {
                    StatusCode = 400
                };
            }

        }
    }
}
