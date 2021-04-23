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
    [Route("api/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        /// </summary>
        /// <param name="appDbContext"></param>

        public RoomController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        //[HttpGet]
        //public List<Room> GetRoom()
        //{


        //    return _appDbContext.Rooms.ToList();
        //}


        // GET: api/<RoomController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _appDbContext.Rooms
                 .Select(RoomViewModel.SelectAllRoom)
                 .ToListAsync();

            return Ok(res);

        }


        //[HttpGet("{Id})")]
        //public Room GetRoomBuild(int Id)
        //{

        //    return _appDbContext.Rooms.FirstOrDefault(x => x.Id == Id);
        //}



        // GET api/<RoomController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _appDbContext.Rooms
                .Select(RoomViewModel.SelectById)
                .FirstOrDefaultAsync();

            return Ok(res);
        }



        //[HttpPost]
        //public List<Room> AddNewRoom([FromBody] Room room)
        //{
        //    _appDbContext.Add(room);
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Rooms.ToList();
        //}


        // POST api/<RoomController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] RoomForm roomForm)
        {
            try
            {
                var modelresources = _mapper.Map<Room>(roomForm);
                await _appDbContext.Rooms.AddAsync(modelresources);
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Rooms
                    .Select(RoomViewModel.SelectAllRoom)
                    .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
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
        //[HttpPut("{id}")]
        //public List<Room> Rooms(int id, [FromBody] Room room)
        //{
        //    if (id == room.Id)
        //    {
        //        _appDbContext.Rooms.Update(room);
        //        _appDbContext.SaveChanges();
        //        return _appDbContext.Rooms.ToList();
        //    }

        //    return null;

        //}



        // PUT api/<RoomController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomForm roomForm)
        {

            try
            {
                var modelresources = _mapper.Map<Room>(roomForm);
                _appDbContext.Rooms.Update(modelresources);
                _appDbContext.SaveChanges();

                var res = await _appDbContext.Rooms
                     .Select(RoomViewModel.SelectAllRoom)
                     .ToListAsync();

                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }



        //[HttpDelete]
        //public List<Room> DeleteRoomFromId(int id)
        //{
        //    _appDbContext.Remove(new Room { Id = id });
        //    _appDbContext.SaveChanges();
        //    return _appDbContext.Rooms.ToList();
        //}


        // DELETE api/<RoomController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Rooms.Remove(new Room { Id = id });
                await _appDbContext.SaveChangesAsync();

                var res = await _appDbContext.Rooms
                    .Select(RoomViewModel.SelectAllRoom)
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
