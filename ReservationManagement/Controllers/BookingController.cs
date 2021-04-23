using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Data;
using ReservationManagement.Models;
using ReservationManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public BookingController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Bookings
                 .Select(BookingViewModel.SelectAllBooking)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Bookings
                .Select(BookingViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<BookingController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] BookingForm bookingForm)
        {
            try
            {
                var modelresources = _mapper.Map<Booking>(bookingForm);
                await _appDbContext.Bookings.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Bookings
                    .Select(BookingViewModel.SelectAllBooking)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<BookingController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] BookingForm bookingForm)
        {

            try
            {
                var modelresources = _mapper.Map<Booking>(bookingForm);
                _appDbContext.Bookings.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Bookings
                     .Select(BookingViewModel.SelectAllBooking)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Bookings.Remove(new Booking { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Bookings
                    .Select(BookingViewModel.SelectAllBooking)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
