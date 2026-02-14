using Microsoft.AspNetCore.Mvc;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return Ok(room);
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok(_context.Rooms.ToList());
        }
    }
}
