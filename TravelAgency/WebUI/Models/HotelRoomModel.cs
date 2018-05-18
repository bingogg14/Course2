﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class HotelRoomModel
    {
        public HotelRoomModel() { }
        public HotelRoomModel(int Number, int SleepingPlaces, int Price)
        {
            this.Number = Number;
            this.SleepingPlaces = SleepingPlaces;
            this.Price = Price;
            IsBooked = false;
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual HotelModel Hotel { get; set; }
        public int Number { get; set; }
        public int SleepingPlaces { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
