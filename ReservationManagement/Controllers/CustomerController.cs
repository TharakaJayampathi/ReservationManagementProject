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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _appDbContext;

        
        /// </summary>
        /// <param name="appDbContext"></param>

        public CustomerController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Customer> GetCustomerModel()
        {


            return _appDbContext.Customers.ToList();
        }

        [HttpGet("{Id})")]
        public Customer GetCustomerBuild(int Id)
        {

            return _appDbContext.Customers.FirstOrDefault(x => x.Id == Id);
        }


        [HttpPost]
        public List<Customer> AddNewCustomer([FromBody] Customer customerModel)
        {
            _appDbContext.Add(customerModel);
            _appDbContext.SaveChanges();
            return _appDbContext.Customers.ToList();
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public List<Customer> Customers(int id, [FromBody] Customer customer)
        {
            if (id == customer.Id)
            {
                _appDbContext.Customers.Update(customer);
                _appDbContext.SaveChanges();
                return _appDbContext.Customers.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Customer> UpdateRoomFromId(int id)
        //{
        //    _appDbContext.Update(new Customer { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Customers.ToList();
        //}

        [HttpDelete]
        public List<Customer> DeleteCustomerFromId(int id)
        {
            _appDbContext.Remove(new Customer { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Customers.ToList();
        }
    }
}
