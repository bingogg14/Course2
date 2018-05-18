﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class HotelRoomReservationModel
    {
        public HotelRoomReservationModel() { }
        public HotelRoomReservationModel(HotelRoomModel HotelRoom, string ClientName, string ClientSurname)
        {
            HotelName = HotelRoom.Hotel.Name;
            HotelStars = HotelRoom.Hotel.Stars;
            HotelAddress = HotelRoom.Hotel.Address;
            HotelRoomNumber = HotelRoom.Number;
            HotelRoomSleepingPlaces = HotelRoom.SleepingPlaces;
            HotelRoomPrice = HotelRoom.Price;
            this.ClientName = ClientName;
            this.ClientSurname = ClientSurname;
        }

        public int Id { get; set; }
        public string HotelName { get; set; }
        public int HotelStars { get; set; }
        public string HotelAddress { get; set; }
        public int HotelRoomNumber { get; set; }
        public int HotelRoomSleepingPlaces { get; set; }
        public int HotelRoomPrice { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
    }
}
