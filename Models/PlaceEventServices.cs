using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;

namespace TravellingReservationApi.Models
{
    [Keyless]
    public class PlaceEvent
    {
        public Place Place { get; set; } 
        public Event[] Events { get; set; }
    }

    public class PlaceEventServices
    {
        private readonly GlobalContext _context;
        public PlaceEventServices(GlobalContext context)
        {
            _context = context;
        }
        public PlaceEvent[] GetAll()
        {
            return (from p in _context.Place
                          select new PlaceEvent
                          {
                              Place = p,
                              Events = _context.Event.Where(x => x.PlaceId == p.PlaceId).ToArray()
                          }).ToArray();

        }
    }
}
