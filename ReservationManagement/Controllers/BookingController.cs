using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationManagement.Data;
using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationManagement.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        
        /// </summary>
        /// <param name="appDbContext"></param>

        public BookingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Booking> GetBooking()
        {


            return _appDbContext.Bookings.ToList();
        }

        [HttpGet("{Id})")]
        public Booking GetBookingBuild(int Id)
        {

            return _appDbContext.Bookings.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Booking> AddNewBooking([FromBody] Booking booking)
        {
            _appDbContext.Add(booking);
            _appDbContext.SaveChanges();
            return _appDbContext.Bookings.ToList();
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public List<Booking> Bookings(int id, [FromBody] Booking booking)
        {
            if (id == booking.Id)
            {
                _appDbContext.Bookings.Update(booking);
                _appDbContext.SaveChanges();
                return _appDbContext.Bookings.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Booking> UpdateBooking([FromBody] Booking booking)
        //{
        //    _appDbContext.Update(booking);
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Bookings.ToList();
        //}

        //[HttpPut]
        //public List<Booking> UpdateRoomFromId(int id)
        //{
        //    _appDbContext.Update(new Booking { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Bookings.ToList();
        //}



        [HttpDelete]
        public List<Booking> DeleteBookingFromId(int id)
        {
            _appDbContext.Remove(new Booking { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Bookings.ToList();
        }
    }
}