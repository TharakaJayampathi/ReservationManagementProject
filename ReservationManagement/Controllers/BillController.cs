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
    [Route("api/bill")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly AppDbContext _appDbContext;

        
        /// </summary>
        /// <param name="appDbContext"></param>

        public BillController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Bill> GetBill()
        {


            return _appDbContext.Bills.ToList();
        }

        [HttpGet("{Id})")]
        public Bill GetBillBuild(int Id)
        {

            return _appDbContext.Bills.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Bill> AddNewBill([FromBody] Bill bill)
        {
            _appDbContext.Add(bill);
            _appDbContext.SaveChanges();
            return _appDbContext.Bills.ToList();
        }

        // PUT api/<BillsController>/5
        [HttpPut("{id}")]
        public List<Bill> Bills(int id, [FromBody] Bill bill)
        {
            if (id == bill.Id)
            {
                _appDbContext.Bills.Update(bill);
                _appDbContext.SaveChanges();
                return _appDbContext.Bills.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Bill> UpdateBill([FromBody] Bill bill)
        //{
        //    _appDbContext.Update(bill);
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Bills.ToList();
        //}

        //[HttpPut]
        //public List<Bill> UpdateBillFromId(int id)
        //{
        //    _appDbContext.Update(new Bill { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Bills.ToList();
        //}



        [HttpDelete]
        public List<Bill> DeleteBillFromId(int id)
        {
            _appDbContext.Remove(new Bill { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Bills.ToList();
        }
    }
}
