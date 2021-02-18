using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;
using TravellingReservationApi.Models;

namespace TravellingReservationApi.Controllers
{
    public class PlaceRequest
    {
        public string PlaceName { get; set; }

        public string PlaceLocation { get; set; }
    }
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly PlaceServices _services;
        private readonly GlobalContext _context;
        public PlacesController(GlobalContext context)
        {
            _context = context;
            _services = new PlaceServices(_context);
        }

        //Get api/places
        [HttpGet]
        public ActionResult<Place[]> Get()
        {
            return _services.GetAll();
        }
        //Get api/places/{id}
        [HttpGet("{id}")]
        public ActionResult<Place> Get(int id)
        {
            return _services.GetPlace(id);
        }
        // Post api/places
        [HttpPost]
        public void Post([FromBody] Place[] requests)
        {
            foreach(var r in requests)
            {
                _services.AddPlace(r);
            }
        }

    }
}
