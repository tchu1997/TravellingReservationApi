using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Data;

namespace TravellingReservationApi.Models
{
    public class Place
    {
        public int? PlaceId { get; internal set; }
        public string PlaceName { get; set; }
        public string PlaceLocation { get; set; }
        
    }
    public class PlaceServices {

        private readonly GlobalContext _context;
        public PlaceServices(GlobalContext context)
        {
            _context = context;
        }
        public Place GetPlace(int id)
        {
            return _context.Place.Where(x => x.PlaceId == id).FirstOrDefault();
        }
        public void AddPlace(Place p)
        {
            if (!IsPlaceExist(p))
            {
                _context.Place.Add(p);
            }
            _context.SaveChanges();
        }
        public Place[] GetAll()
        {
            return _context.Place.ToArray();
        }
        public bool IsPlaceExist(Place p)
        {
            if (_context.Place.FirstOrDefault(x => x.PlaceName == p.PlaceName && x.PlaceLocation == p.PlaceLocation) == null)
            {
                return false;
            }
            return true;
        }
    }
}
