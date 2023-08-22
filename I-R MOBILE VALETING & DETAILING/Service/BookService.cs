using I_R_MOBILE_VALETING___DETAILING.Data;
using I_R_MOBILE_VALETING___DETAILING.Data.Models;
using I_R_MOBILE_VALETING___DETAILING.Models;
using I_R_MOBILE_VALETING___DETAILING.Service.Contract;

namespace I_R_MOBILE_VALETING___DETAILING.Service
{
    public class BookService:IBookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateBooking(Book book)
        {
           var booking = new Booking
           {
               Name = book.Name,
               Phone = book.Phone,
               Email = book.Email,
               Address = book.Address,
               WashType = book.WashType,
               Description = book.Description,
               Date = book.Date,
               Time = book.Time
           };

            await _db.Bookings.AddAsync(booking);
            await _db.SaveChangesAsync();
        }
    }
}
