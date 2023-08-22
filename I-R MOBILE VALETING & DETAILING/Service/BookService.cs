using I_R_MOBILE_VALETING___DETAILING.Data;
using I_R_MOBILE_VALETING___DETAILING.Data.Models;
using I_R_MOBILE_VALETING___DETAILING.Models;
using I_R_MOBILE_VALETING___DETAILING.Service.Contract;
using System.Net;
using System.Net.Mail;

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
               Date = book.Date.Date,
               Time = book.Time
           };

            await _db.Bookings.AddAsync(booking);
            await _db.SaveChangesAsync();
        }

        public async Task SendEmailOnGmail(string sender, Book book)
        {
            MailMessage mm = new MailMessage(book.Email, sender);
            mm.Subject = "Car Wash Booking Confirmation";

            // Create an HTML-formatted body with improved styling
            string body = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    margin: 0;
                    padding: 0;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    background-color: #ffffff;
                    border-radius: 10px;
                    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
                }}
                .header {{
                    text-align: center;
                    margin-bottom: 20px;
                }}
                .details {{
                    margin-bottom: 20px;
                }}
                .detail {{
                    margin-bottom: 10px;
                }}
                .detail strong {{
                    display: inline-block;
                    width: 120px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h1>Car Wash Booking Confirmation</h1>
                </div>
                <div class='details'>
                    <div class='detail'>
                        <strong>Name:</strong> {book.Name}
                    </div>
                    <div class='detail'>
                        <strong>Phone:</strong> {book.Phone}
                    </div>
                    <div class='detail'>
                        <strong>Email:</strong> {book.Email}
                    </div>
                    <div class='detail'>
                        <strong>Address:</strong> {book.Address}
                    </div>
                    <div class='detail'>
                        <strong>Wash Type:</strong> {book.WashType}
                    </div>
                    <div class='detail'>
                        <strong>Description:</strong> {book.Description}
                    </div>
                    <div class='detail'>
                        <strong>Date:</strong> {book.Date}
                    </div>
                    <div class='detail'>
                        <strong>Time:</strong> {book.Time}
                    </div>
                </div>
            </div>
        </body>
        </html>";

            mm.Body = body;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            NetworkCredential nc = new NetworkCredential(sender, "yzbulzekjrjhifql");
            smtp.Credentials = nc;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(mm);
        }


    }
}
