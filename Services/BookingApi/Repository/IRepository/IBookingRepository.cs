using BookingApi.Models;

namespace BookingApi.Repository.IRepository
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingDetails>> GetAllByUserName(string userName);
        Task<IEnumerable<BookingDetails>> GetAllByProfessional(string ProfessionalName);
        Task<BookingDetails> GetDetailsById(int id);
        Task<BookingDetails> PostBooking(BookingDetails newBookingDetails);
        Task<BookingDetails> UpdateServiceResponse(BookingResponse bookingResponse);
        Task<BookingDetails> UpdatePaymentResponse(BookingResponse bookingResponse);
        Task<BookingDetails> CancelBooking(BookingDetails cancelBooking);
    }
    
    
}
