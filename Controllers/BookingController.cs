using Microsoft.AspNetCore.Mvc;
using HotelManagementAPI.Data;
using HotelManagementAPI.DTOs;
using HotelManagementAPI.Models;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BookingController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom([FromForm] BookingDto dto)
        {
            var aadhaarPath = Path.Combine("Uploads/Aadhaar", dto.Aadhaar.FileName);
            var photoPath = Path.Combine("Uploads/Photos", dto.Photo.FileName);

            using (var stream = new FileStream(Path.Combine(_env.ContentRootPath, aadhaarPath), FileMode.Create))
            {
                await dto.Aadhaar.CopyToAsync(stream);
            }

            using (var stream = new FileStream(Path.Combine(_env.ContentRootPath, photoPath), FileMode.Create))
            {
                await dto.Photo.CopyToAsync(stream);
            }

            var booking = new Booking
            {
                RoomId = dto.RoomId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                AadhaarPath = aadhaarPath,
                PhotoPath = photoPath
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok("Room Booked Successfully");
        }
    }
}
