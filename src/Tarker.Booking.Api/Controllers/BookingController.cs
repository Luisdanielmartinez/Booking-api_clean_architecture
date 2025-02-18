using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingByType;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand, [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
            }

            var data = await createBookingCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingQuery getAllBookingQuery)
        {
            var data = await getAllBookingQuery.Execute();

            if (data == null || data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-documentNumber/{documentNumber}")]
        public async Task<IActionResult> GetById(string documentNumber, [FromServices] IGetBookingsByDocumentNumberQuery getBookingsByDocumentNumberQuery)
        {
            var data = await getBookingsByDocumentNumberQuery.Execute(documentNumber);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-type/{type}")]
        public async Task<IActionResult> GetById(string type, [FromServices] IGetBookingByTypeQuery getBookingByTypeQuery)
        {
            var data = await getBookingByTypeQuery.Execute(type);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }

}
