using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingReservationApi.Models;

namespace TravellingReservationApi.Data
{
    public class GlobalContext : DbContext
    {
        public GlobalContext(DbContextOptions<GlobalContext> options) : base(options)
        {
        }
        public GlobalContext() { }

        public DbSet<Place> Place { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Booking> Booking { get; set; }

    }
}
