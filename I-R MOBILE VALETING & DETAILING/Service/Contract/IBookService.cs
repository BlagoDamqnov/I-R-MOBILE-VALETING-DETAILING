using I_R_MOBILE_VALETING___DETAILING.Models;

namespace I_R_MOBILE_VALETING___DETAILING.Service.Contract
{
    public interface IBookService
    {
        Task CreateBooking(Book book);
        Task SendEmailOnGmail(string sender,Book book);
    }
}
