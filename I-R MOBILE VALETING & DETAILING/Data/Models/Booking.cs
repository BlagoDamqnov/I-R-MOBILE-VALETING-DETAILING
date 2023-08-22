namespace I_R_MOBILE_VALETING___DETAILING.Data.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string WashType { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } = null!;

    }
}
