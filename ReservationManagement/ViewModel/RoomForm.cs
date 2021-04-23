using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class RoomForm
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

    public static class RoomViewModel
    {

        public static Expression<Func<Room, object>> SelectAllRoom =>
            x => new
            {
                Id = x.Id,
                RoomNo = x.No,
                Members = x.Members,
                Beds = x.Beds,
                RoomStatus = x.RoomStatus
            };
        public static Expression<Func<Room, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                RoomNo = x.No,
                Members = x.Members,
                Beds = x.Beds,
                RoomStatus = x.RoomStatus
            };


    }


}
