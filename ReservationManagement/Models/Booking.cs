using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(150)]
        //public string FirstName { get; set; }

        //[Required]
        //[StringLength(150)]
        //public string LastName { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public bool PaymentStatus { get; set; }

        public string Description { get; set; }

        //public string Email { get; set; }

        //public string PhoneNo { get; set; }

        //[Required]
        //[StringLength(150)]
        //public string Address { get; set; }

        public int Members { get; set; }

        [Required]
        public string RoomType { get; set; }
    }
}
