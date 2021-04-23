using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class BookingForm
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

    public static class BookingViewModel
    {

        public static Expression<Func<Booking, object>> SelectAllBooking =>
            x => new
            {
                Id = x.Id,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                Description = x.Description,
                Members = x.Members,
                RoomType = x.RoomType
            };
        public static Expression<Func<Booking, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                Description = x.Description,
                Members = x.Members,
                RoomType = x.RoomType
            };


    }
}
