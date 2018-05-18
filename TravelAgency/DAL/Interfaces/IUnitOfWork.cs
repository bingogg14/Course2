using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        /*IRepository<Hotel> Hotels { get; set; }
        IRepository<HotelRoom> HotelsRooms { get; set; }
        IRepository<Tour> ToursTemplates { get; set; }
        IRepository<Transport> Transports { get; set; }

        IRepository<User> Users { get; set; }
        IRepository<Tour> OrderedTours { get; set; }
        IRepository<HotelRoomReservation> HotelsRoomsReservations { get; set; }
        IRepository<TransportPlace> TransportsPlace { get; set; }*/

        void DeleteDB();
    }
}
