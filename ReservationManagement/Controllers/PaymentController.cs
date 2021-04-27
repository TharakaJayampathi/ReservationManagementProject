using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Data;
using ReservationManagement.Models;
using ReservationManagement.ViewModel;
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
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public PaymentController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Payments
                 .Select(PaymentViewModel.SelectAllPayment)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Payments
                .Select(PaymentViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<Controller>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] PaymentForm paymentForm)
        {
            try
            {
                var modelresources = _mapper.Map<Payment>(paymentForm);
                await _appDbContext.Payments.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Payments
                    .Select(PaymentViewModel.SelectAllPayment)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<PaymentController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PaymentForm paymentForm)
        {

            try
            {
                var modelresources = _mapper.Map<Payment>(paymentForm);
                _appDbContext.Payments.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Payments
                     .Select(PaymentViewModel.SelectAllPayment)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Payments.Remove(new Payment { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Payments
                    .Select(PaymentViewModel.SelectAllPayment)
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
