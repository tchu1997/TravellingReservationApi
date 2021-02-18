using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;
using TravellingReservationApi.Models;
using static TravellingReservationApi.Models.PlaceEvent;

namespace TravellingReservationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceEventController : ControllerBase
    {
        private readonly PlaceEventServices _services;
        private readonly GlobalContext _context;
        public PlaceEventController(GlobalContext context)
        {
            _context = context;
            _services = new PlaceEventServices(_context);
        }
        [HttpGet]
        public ActionResult<PlaceEvent[]> Get(){
            return _services.GetAll();
        }
    }
}
