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
    public class HotelLogic
    {
         UnitOfWork UoW;

        public HotelLogic(UnitOfWork UoW)
        {
            HotelLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelDTO, Hotel>();
                cfg.CreateMap<HotelRoomDTO, HotelRoom>();
                cfg.CreateMap<Hotel, HotelDTO>();
                cfg.CreateMap<HotelRoom, HotelRoomDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper HotelLogicMapper;

        public HotelLogic()
        {
            HotelLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HotelDTO, Hotel>();
                cfg.CreateMap<HotelRoomDTO, HotelRoom>();
                cfg.CreateMap<Hotel, HotelDTO>();
                cfg.CreateMap<HotelRoom, HotelRoomDTO > ();
            }).CreateMapper();
            UoW = new UnitOfWork();
        }

        public void AddHotel(HotelDTO NewHotel)
        {
            UoW.Hotels.Add(HotelLogicMapper.Map<HotelDTO, Hotel>(NewHotel));
        }

        public void DeleteHotel(int Id)
        {
            UoW.Hotels.Delete(Id);
        }

        public void AddHotelRoom(int HotelId, HotelRoomDTO NewHotelRoom)
        {
            Hotel temp = UoW.Hotels.Get(HotelId);
            HotelRoom room = HotelLogicMapper.Map<HotelRoom>(NewHotelRoom);
            room.Hotel = temp;
            //UoW.HotelsRooms.Add(room);
            temp.Rooms.Add(room);
            UoW.Hotels.Modify(temp);
        }


        public IEnumerable<HotelDTO> GetAllHotels()
        {
            return HotelLogicMapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(UoW.Hotels.GetAll(h => h.Rooms));
        }

        public HotelDTO GetHotel(int Id)
        {
            return GetAllHotels().FirstOrDefault(h => h.Id == Id);
        }
    }
}
