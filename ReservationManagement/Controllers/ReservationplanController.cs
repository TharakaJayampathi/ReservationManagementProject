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
    [Route("api/reservationplan")]
    [ApiController]
    public class ReservationplanController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public ReservationplanController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<ReservationplanController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Reservationplans
                 .Select(ReservationplanViewModel.SelectAllReservationplan)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<ReservationplanController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Reservationplans
                .Select(ReservationplanViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<ReservationplanController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] ReservationplanForm reservationplanForm)
        {
            try
            {
                var modelresources = _mapper.Map<Reservationplan>(reservationplanForm);
                await _appDbContext.Reservationplans.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Reservationplans
                    .Select(ReservationplanViewModel.SelectAllReservationplan)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<ReservationplanController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ReservationplanForm reservationplanForm)
        {

            try
            {
                var modelresources = _mapper.Map<Reservationplan>(reservationplanForm);
                _appDbContext.Reservationplans.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Reservationplans
                     .Select(ReservationplanViewModel.SelectAllReservationplan)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<ReservationplanController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Reservationplans.Remove(new Reservationplan { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Reservationplans
                    .Select(ReservationplanViewModel.SelectAllReservationplan)
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