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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public CustomerController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Customers
                 .Select(CustomerViewModel.SelectAllCustomer)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Customers
                .Select(CustomerViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<CustomerController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] CustomerForm customerForm)
        {
            try
            {
                var modelresources = _mapper.Map<Customer>(customerForm);
                await _appDbContext.Customers.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Customers
                    .Select(CustomerViewModel.SelectAllCustomer)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<CustomerController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerForm customerForm)
        {

            try
            {
                var modelresources = _mapper.Map<Customer>(customerForm);
                _appDbContext.Customers.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Customers
                     .Select(CustomerViewModel.SelectAllCustomer)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Customers.Remove(new Customer { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Customers
                    .Select(CustomerViewModel.SelectAllCustomer)
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
