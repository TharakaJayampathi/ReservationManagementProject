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

        [Required]
        public int No { get; set; }

        [Required]
        public int Members { get; set; }

        [Required]
        public int Beds { get; set; }

        [Required]
        public bool RoomStatus { get; set; }



    }
}

