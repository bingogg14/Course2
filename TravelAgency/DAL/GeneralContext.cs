using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class GeneralContext : DbContext
    {
        public GeneralContext() { }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomReservation> HotelRoomReservations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportPlace> TransportPlaces { get; set; }
        public DbSet<TransportTicket> TransportTickets { get; set; }
    }
}
