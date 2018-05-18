using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Logic.DTOs;
using AutoMapper;

namespace Logic
{
    public class UserLogic
    {
        UnitOfWork UoW;

        public UserLogic(UnitOfWork UoW)
        {
            UserLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Transport, TransportDTO>();
                cfg.CreateMap<TransportPlace, TransportPlaceDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper UserLogicMapper;

        public UserLogic()
        {
            UserLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Transport, TransportDTO>();
                cfg.CreateMap<TransportPlace, TransportPlaceDTO>();
            }).CreateMapper();
            UoW = new UnitOfWork();
        }

        public void AddUser(UserDTO NewUser)
        {
            UoW.Users.Add(UserLogicMapper.Map<UserDTO, User>(NewUser));
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return UserLogicMapper.Map<IEnumerable<User>,List<UserDTO>>(UoW.Users.GetAll(u => u.HotelRoomReservations, u => u.TransportTickets, u => u.Tours));
        }

        public UserDTO GetUser(int Id)
        {
            return GetAllUsers().FirstOrDefault(u => u.Id == Id);
        }

        public void EditUser(int Id, UserDTO User)
        {
            UoW.Users.Modify(Id, UserLogicMapper.Map<UserDTO, User>(User));
        }

        public void DeleteUser(int Id)
        {
            UoW.Users.Delete(Id);
        }

        public UserDTO Enter(string Login, string Password)
        {
            UserDTO user = GetAllUsers().FirstOrDefault(u => u.Login == Login && u.Password == Password);
            if (user == null)
                throw new InvalidLoginPasswordCombinationException("Invalid login password combination");
            return user;
        }

        public void ReserveTour(int UserId, int TourId)
        {
            Tour tour = UoW.ToursTemplates.Get(TourId);
            User user = UoW.Users.Get(UserId);
            user.Tours.Add(tour);
            UoW.Users.Modify(user);
        }

        public void ReserveRoom(int UserId, int HotelId, int HotelRoomId)
        {
            User user = UoW.Users.GetAll(u => u.HotelRoomReservations).First(x => x.Id == UserId);
            HotelRoom temp = UoW.Hotels.GetAll(h => h.Rooms).Find(h => h.Id == HotelId).Rooms.Find(r => r.Id == HotelRoomId);
            if (temp.IsBooked)
                throw new AlreadyBookedItemException("Room is already booked");
            else
            {
                temp.IsBooked = true;
                UoW.HotelsRooms.Modify(temp);
                var reserv = new HotelRoomReservation(temp, user.Name, user.Surname);
                UoW.HotelsRoomsReservations.Add(reserv);
                user.HotelRoomReservations.Add(reserv);
                UoW.Users.Modify(user);
            }
        }

        public void ReserveTicket(int UserId, int TransportId, int SeatNumber)
        {
            User user = UoW.Users.Get(UserId);
            TransportPlace temp = UoW.Transports.Get(TransportId).TransportPlaces.Find(r => r.Number == SeatNumber);
            if (temp.IsBooked)
                throw new AlreadyBookedItemException("Transport place is already booked");
            else
            {
                temp.IsBooked = true;
                UoW.Transports.Modify(UoW.Transports.Get(TransportId));
                user.TransportTickets.Add(new TransportTicket(temp, user.Name, user.Surname));
            }
        }
    }
}
