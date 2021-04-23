using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationManagement.Data;
using ReservationManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public LoginController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> CheckLoginDetailsAsync([FromQuery] LoginForm loginForm)
        {
            var data = await _appDbContext.Logins.Where(x => x.Email == loginForm.Email).FirstOrDefaultAsync();

            if (data.Password == loginForm.Password)
            {
                return Ok("valid");
            }

            return Unauthorized();
        }
    }
}
