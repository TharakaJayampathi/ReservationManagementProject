using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class Reservationplan
    {
        public int Id { get; set; }

        [Required]
        public string ReservationplanType { get; set; }


        //[Required]
        //public double RoomTypeAmount { get; set; }

        //[Required]
        //public int Rooms { get; set; }

        //[Required]
        //public int Days { get; set; }
        //public int CustomerId { get; set; }

        //public double _payment;
        //public double Payment
        //{
        //    get 
        //    {
        //        return RoomTypeAmount * Rooms * Days;
        //    }

        //    set
        //    {
        //        _payment = Payment;
        //    }
        //}

    }
}