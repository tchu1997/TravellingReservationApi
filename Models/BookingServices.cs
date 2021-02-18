using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;

namespace TravellingReservationApi.Models
{
    public class Booking
    {
        public int? BookingId { get; internal set; }
        public int EventId { get; set; }
        public int TicketCount { get; set; }
        public string Name { get; set; }
    }
    public class BookingServices
    {
        private readonly GlobalContext _context;
        public BookingServices(GlobalContext context)
        {
            _context = context;
        }
        public void AddBooking(Booking b)
        {
            _context.Booking.Add(b);
        }
    }
}
