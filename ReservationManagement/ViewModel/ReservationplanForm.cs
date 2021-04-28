using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class ReservationplanForm
    {
        public int Id { get; set; }

        [Required]
        public string ReservationplanType { get; set; }
    }

    public static class ReservationplanViewModel
    {

        public static Expression<Func<Reservationplan, object>> SelectAllReservationplan =>
            x => new
            {
                Id = x.Id,
                ReservationplanType = x.ReservationplanType

            };
        public static Expression<Func<Reservationplan, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                ReservationplanType = x.ReservationplanType

            };


    }
}
