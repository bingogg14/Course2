using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class HotelRoomDTO
    {
        public HotelRoomDTO() { }
        public HotelRoomDTO(int Number, int SleepingPlaces, int Price)
        {
            this.Number = Number;
            this.SleepingPlaces = SleepingPlaces;
            this.Price = Price;
            IsBooked = false;
        }

        public int Id { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public virtual HotelDTO Hotel { get; set; }
        public int Number { get; set; }
        public int SleepingPlaces { get; set; }
        public int Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
