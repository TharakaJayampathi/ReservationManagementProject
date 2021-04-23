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
            CreateMap<RoomForm, Room>();
            CreateMap<BillForm, Bill>();
            CreateMap<BookingForm, Booking>();
            CreateMap<CustomerForm, Customer>();
            CreateMap<LoginForm, Login>();

        }
    }
}

