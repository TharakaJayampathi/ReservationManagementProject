using AutoMapper;
using ReservationManagement.Models;
using ReservationManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BillForm, Bill>();
            CreateMap<BookingForm, Booking>();
            CreateMap<CustomerForm, Customer>();
            CreateMap<LoginForm, Login>();
            CreateMap<RoomForm, Room>();
            CreateMap<UserForm, User>();
            CreateMap<ReservationplanForm, Reservationplan>();


        }
    }
}

