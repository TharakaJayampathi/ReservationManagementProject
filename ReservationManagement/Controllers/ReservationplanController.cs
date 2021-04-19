using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationManagement.Data;
using ReservationManagement.Models;
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

        /// <summary>
        /// Dispendency Enjection (DI)
        /// </summary>
        /// <param name="appDbContext"></param>

        public ReservationplanController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Reservationplan> GetReservationplan()
        {


            return _appDbContext.Reservationplans.ToList();
        }

        [HttpGet("{Id})")]
        public Reservationplan GetRseervationplanBuild(int Id)
        {

            return _appDbContext.Reservationplans.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Reservationplan> AddNewReservationplan([FromBody] Reservationplan reservationplan)
        {
            _appDbContext.Add(reservationplan);
            _appDbContext.SaveChanges();
            return _appDbContext.Reservationplans.ToList();
        }

        // PUT api/<ReservationplansController>/5
        [HttpPut("{id}")]
        public List<Reservationplan> Reservationplans(int id, [FromBody] Reservationplan reservationplan)
        {
            if (id == reservationplan.Id)
            {
                _appDbContext.Reservationplans.Update(reservationplan);
                _appDbContext.SaveChanges();
                return _appDbContext.Reservationplans.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Customer> UpdateReservationplanFromId(int id)
        //{
        //    _appDbContext.Update(new Reservationplan { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Reservationplans.ToList();
        //}

        [HttpDelete]
        public List<Reservationplan> DeleteReservationplanFromId(int id)
        {
            _appDbContext.Remove(new Reservationplan { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Reservationplans.ToList();
        }
    }
}