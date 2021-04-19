using Microsoft.AspNetCore.Mvc;
using ReservationManagement.Data;
using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationManagement.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly AppDbContext _appDbContext;


        /// </summary>
        /// <param name="appDbContext"></param>

        public PaymentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Payment> GetPayment()
        {


            return _appDbContext.Payments.ToList();
        }

        [HttpGet("{Id})")]
        public Payment GetPaymentBuild(int Id)
        {

            return _appDbContext.Payments.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Payment> AddNewPayment([FromBody] Payment payment)
        {
            _appDbContext.Add(payment);
            _appDbContext.SaveChanges();
            return _appDbContext.Payments.ToList();
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public List<Payment> Payments(int id, [FromBody] Payment payment)
        {
            if (id == payment.Id)
            {
                _appDbContext.Payments.Update(payment);
                _appDbContext.SaveChanges();
                return _appDbContext.Payments.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Payment> UpdatePayment([FromBody] Payment payment)
        //{
        //    _appDbContext.Update(payment);
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Payments.ToList();
        //}

        //[HttpPut]
        //public List<Payment> UpdatePaymentFromId(int id)
        //{
        //    _appDbContext.Update(new Payment { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Payments.ToList();
        //}



        [HttpDelete]
        public List<Payment> DeletePaymentFromId(int id)
        {
            _appDbContext.Remove(new Payment { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Payments.ToList();
        }
    }
}
