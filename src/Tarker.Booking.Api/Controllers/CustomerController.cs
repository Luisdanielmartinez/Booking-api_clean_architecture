using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
       public async Task<IActionResult> Create([FromBody]CreateCustomerModel model, [FromServices] ICreateCustomerCommand createCustomerCommand )
        {
            var data = await createCustomerCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created,
               ResponseApiService.Response(StatusCodes.Status201Created, data));
        }
    }
}
