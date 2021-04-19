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
    [Route("api/usermanagement")]
    [ApiController]
    public class UsermanagementController : Controller
    {
        private readonly AppDbContext _appDbContext;


        /// </summary>
        /// <param name="appDbContext"></param>

        public UsermanagementController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Usermanagement> GetUsermanagement()
        {


            return _appDbContext.Usermanagements.ToList();
        }

        [HttpGet("{Id})")]
        public Usermanagement GetUsermanagementBuild(int Id)
        {

            return _appDbContext.Usermanagements.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Usermanagement> AddNewUsermanagement([FromBody] Usermanagement usermanagement)
        {
            _appDbContext.Add(usermanagement);
            _appDbContext.SaveChanges();
            return _appDbContext.Usermanagements.ToList();
        }

        // PUT api/<UsermanagementsController>/5
        [HttpPut("{id}")]
        public List<Usermanagement> Usermanagements(int id, [FromBody] Usermanagement usermanagement)
        {
            if (id == usermanagement.Id)
            {
                _appDbContext.Usermanagements.Update(usermanagement);
                _appDbContext.SaveChanges();
                return _appDbContext.Usermanagements.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Usermanagement> UpdateUsermanagement([FromBody] Usermanagement usermanagement)
        //{
        //    _appDbContext.Update(usermanagement);
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Usermanagements.ToList();
        //}

        //[HttpPut]
        //public List<Usermanagement> UpdateUsermanagementFromId(int id)
        //{
        //    _appDbContext.Update(new Usermanagement { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Usermanagements.ToList();
        //}



        [HttpDelete]
        public List<Usermanagement> DeleteUsermanagementFromId(int id)
        {
            _appDbContext.Remove(new Usermanagement { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Usermanagements.ToList();
        }
    }
}
