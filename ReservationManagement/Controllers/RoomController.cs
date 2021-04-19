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
    [Route("api/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly AppDbContext _appDbContext;

        /// </summary>
        /// <param name="appDbContext"></param>

        public RoomController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Room> GetRoom()
        {


            return _appDbContext.Rooms.ToList();
        }

        [HttpGet("{Id})")]
        public Room GetRoomBuild(int Id)
        {

            return _appDbContext.Rooms.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public List<Room> AddNewRoom([FromBody] Room room)
        {
            _appDbContext.Add(room);
            _appDbContext.SaveChanges();
            return _appDbContext.Rooms.ToList();
        }

        //if (Room != null)
        //    {
        //        Room.IsRoomStatus = true;
        //        Room.Date = DateTime.Now;
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        db.Rooms.Add(Room);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Booking");
        //    }

        //    return View(Room);

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public List<Room> Rooms(int id, [FromBody] Room room)
        {
            if (id == room.Id)
            {
                _appDbContext.Rooms.Update(room);
                _appDbContext.SaveChanges();
                return _appDbContext.Rooms.ToList();
            }

            return null;

        }

        //[HttpPut]
        //public List<Room> UpdateRoomFromId(int id)
        //{
        //    _appDbContext.Update(new Room { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Rooms.ToList();
        //}

        [HttpDelete]
        public List<Room> DeleteRoomFromId(int id)
        {
            _appDbContext.Remove(new Room { Id = id });
            _appDbContext.SaveChanges();
            return _appDbContext.Rooms.ToList();
        }
    }
}
