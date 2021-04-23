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
    [Route("api/bill")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public BillController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<BillController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Bills
                 .Select(BillViewModel.SelectAllBill)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Bills
                .Select(BillViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<BillController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] BillForm billForm)
        {
            try
            {
                var modelresources = _mapper.Map<Bill>(billForm);
                await _appDbContext.Bills.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Bills
                    .Select(BillViewModel.SelectAllBill)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<BillController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] BillForm billForm)
        {

            try
            {
                var modelresources = _mapper.Map<Bill>(billForm);
                _appDbContext.Bills.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Bills
                     .Select(BillViewModel.SelectAllBill)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Bills.Remove(new Bill { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Bills
                    .Select(BillViewModel.SelectAllBill)
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
