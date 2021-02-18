using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;

namespace TravellingReservationApi.Models
{
    public class Event {

        public int? EventId { get; internal set; }

        public int PlaceId { get; set; }
        public string EventName { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
        public int EventTicketCount { get; set; }
        public int AvailableTicketCount { get; set; }
    }
    public class EventServices
    {
        private readonly GlobalContext _context;
        public EventServices(GlobalContext context)
        {
            _context = context;
        }
        public Event GetEvent(int id)
        {
            return _context.Event.Where(x => x.EventId == id).FirstOrDefault();
        }
        public void AddEvent(Event e)
        {
            if (!IsEventExist(e))
            {
                _context.Event.Add(e);
            }
            _context.SaveChanges();
        }
        public Event[] GetAll()
        {
            return _context.Event.ToArray();
        }
        public bool IsEventExist(Event e)
        {
            if (_context.Event.FirstOrDefault(x => x.EventName == e.EventName 
                                                && x.PlaceId == e.PlaceId 
                                                && x.Since == e.Since 
                                                && x.Until == e.Until) == null)
            {
                return false;
            }
            return true;
        }

    }
}
