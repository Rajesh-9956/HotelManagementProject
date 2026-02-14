using Microsoft.AspNetCore.Mvc;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return Ok(hotel);
        }

        [HttpGet]
        public IActionResult GetHotels()
        {
            return Ok(_context.Hotels.ToList());
        }
    }
}
