using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class BillForm
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public double RoomTypeAmount { get; set; }

        [Required]
        public int Rooms { get; set; }

        [Required]
        public int Days { get; set; }

        public double _payment;
        public double Payment
        {
            get
            {
                return RoomTypeAmount * Rooms * Days;
            }

            set
            {
                _payment = Payment;
            }
        }
    }

    public static class BillViewModel
    {

        public static Expression<Func<Bill, object>> SelectAllBill =>
            x => new
            {
                Id = x.Id,
                Date = x.Date,
                RoomTypeAmount = x.RoomTypeAmount,
                Rooms = x.Rooms,
                Days = x.Days,
                Payment = x.Payment
            };
        public static Expression<Func<Bill, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                Date = x.Date,
                RoomTypeAmount = x.RoomTypeAmount,
                Rooms = x.Rooms,
                Days = x.Days,
                Payment = x.Payment
            };


    }
}
