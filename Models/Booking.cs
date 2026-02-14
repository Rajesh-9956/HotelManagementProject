namespace HotelManagementAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RoomId { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string AadhaarPath { get; set; }
        public string PhotoPath { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
