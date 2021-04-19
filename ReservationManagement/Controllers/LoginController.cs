using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Application;
using ReservationManagement.Data;
using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationManagement.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AppDbContext _appDbContext;

       
        /// <param name="appDbContext"></param>

        public LoginController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Login> GetLogin()
        {


            return _appDbContext.Logins.ToList();
        }

        [HttpGet("{Id})")]
        public Login GetLoginBuild(int Id)
        {

            return _appDbContext.Logins.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Login> AddNewLogin([FromBody] Login login)
        {

            _appDbContext.Add(login);
            _appDbContext.SaveChanges();
            return _appDbContext.Logins.ToList();
        }

        [HttpDelete]
        public List<Login> DeleteLoginFromId(int id)
        {
            _appDbContext.Remove(new Login { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Logins.ToList();
        }

        [HttpPost("login")]

        public Result ValidateLogin([FromBody] LoginViewModel loginViewModel)
        {
            var x = _appDbContext.Logins.FirstOrDefault(x => x.Email == loginViewModel.Email);

            if (x == null)
            {
                return Result.NotFound();
            }

            if (x.Password != loginViewModel.Password)
            {
                return Result.Failed();
            }

            var data = _appDbContext.Customers.Include(x => x.Usermanagement).FirstOrDefault(x => x.Email == loginViewModel.Email);
            if (data.Age <= 18)
            {
                return Result.Success(data);
            }

            else
            {
                return Result.Unsuccess("Your age is not 18+", 400);
            }






        }



    }

}
