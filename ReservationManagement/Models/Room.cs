using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class Room
    {
        public int Id { get; set; }
        
        public int No { get; set; }
        public int Members { get; set; }

        public int Beds { get; set; }
        public bool RoomStatus { get; set; }

        //public int RoomplanId { get; set; }

        public Booking Booking { get; set; }

        public Reservationplan Reservationplan { get; set; }
        

    }
}
