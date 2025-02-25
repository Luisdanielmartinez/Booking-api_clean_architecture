using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.Extermal.GetTokenJwt;
using Tarker.Booking.Application.Validators.Booking;
using Tarker.Booking.External.GetTokenJwt;

namespace Tarker.Booking.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            return services;
        }
    }
}
