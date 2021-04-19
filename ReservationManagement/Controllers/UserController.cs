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
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Dispendency Enjection (DI)
        /// </summary>
        /// <param name="appDbContext"></param>

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<User> GetUserModel()
        {


            return _appDbContext.Users.ToList();
        }

        [HttpGet("{Id})")]
        public User GetUserBuild(int Id)
        {

            return _appDbContext.Users.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<User> AddNewUser([FromBody] User userModel)
        {
            _appDbContext.Add(userModel);
            _appDbContext.SaveChanges();
            return _appDbContext.Users.ToList();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public List<User> Users(int id, [FromBody] User user)
        {
            if (id == user.Id)
            {
                _appDbContext.Users.Update(user);
                _appDbContext.SaveChanges();
                return _appDbContext.Users.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<User> UpdateRoomFromId(int id)
        //{
        //    _appDbContext.Update(new User { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Users.ToList();
        //}

        [HttpDelete]
        public List<User> DeleteUserFromId(int id)
        {
            _appDbContext.Remove(new User { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Users.ToList();
        }
    }
}
