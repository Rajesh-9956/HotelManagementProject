using Microsoft.AspNetCore.Http;

namespace HotelManagementAPI.DTOs
{
    public class BookingDto
    {
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public IFormFile Aadhaar { get; set; }
        public IFormFile Photo { get; set; }
    }
}
