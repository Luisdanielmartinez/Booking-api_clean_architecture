using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public class CreateBookingModel
    {
        public int BookingId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
