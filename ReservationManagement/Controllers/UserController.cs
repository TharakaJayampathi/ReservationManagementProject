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
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public UserController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Users
                 .Select(UserViewModel.SelectAllUser)
                 .ToListAsync();

            return Ok(res);

        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Users
                .Select(UserViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        // POST api/<UserController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] UserForm userForm)
        {
            try
            {
                var modelresources = _mapper.Map<User>(userForm);
                await _appDbContext.Users.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Users
                    .Select(UserViewModel.SelectAllUser)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserForm userForm)
        {

            try
            {
                var modelresources = _mapper.Map<User>(userForm);
                _appDbContext.Users.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Users
                     .Select(UserViewModel.SelectAllUser)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Users.Remove(new User { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Users
                    .Select(UserViewModel.SelectAllUser)
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
