using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;
using TravellingReservationApi.Models;

namespace TravellingReservationApi.Controllers
{
    public class EventRequest
    {
        public int PlaceId { get; set; }
        public string EventName { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
        public int EventTicketCount { get; set; }
        public int AvailableTicketCount { get; set; }
    }
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventServices _services;
        private readonly GlobalContext _context;
        public EventsController(GlobalContext context)
        {
            _context = context;
            _services = new EventServices(_context);
        }

        //Get api/places
        [HttpGet]
        public ActionResult<Event[]> Get()
        {
            return _services.GetAll();
        }
        //Get api/events/{id}
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            return _services.GetEvent(id);
        }
        // Post api/events
        [HttpPost]
        public void Post([FromBody] Event[] requests)
        {
            foreach (var r in requests)
            {
                _services.AddEvent(r);
            }
        }
    }
}
