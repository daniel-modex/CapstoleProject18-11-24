using BookingApi.Data;
using BookingApi.Models;
using BookingApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly BookingDBContext _dbContext;

        public BookingRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookingDetails> CancelBooking(BookingDetails cancelBooking)
        {
            var details = await _dbContext.BookingDetails.FindAsync(cancelBooking.Id);
            if (details == null)
            {
                return new BookingDetails();
            }
            details.CancelationConfirmed = true;
            await _dbContext.SaveChangesAsync();
            return details;
        }

        public async Task<IEnumerable<BookingDetails>> GetAllByProfessional(string ProfessionalName)
        {
            return await _dbContext.BookingDetails.Where(x=>x.ProfessionalName == ProfessionalName).ToListAsync();
        }

        public async Task<IEnumerable<BookingDetails>> GetAllByUserName(string userName)
        {
            return await _dbContext.BookingDetails.Where(x => x.UserName == userName).ToListAsync();
        }

        public async Task<BookingDetails> GetDetailsById(int id)
        {
            var details = await _dbContext.BookingDetails.FindAsync(id);
            if (details == null)
            {
                return new BookingDetails();
            }
            return details;
        }

        public async Task<BookingDetails> PostBooking(BookingDetails newBookingDetails)
        {
            newBookingDetails.BookingRequestedSuccessfully = true;
            _dbContext.BookingDetails.Add(newBookingDetails);
            await _dbContext.SaveChangesAsync();
            return newBookingDetails;
        }

        public async Task<BookingDetails> UpdatePaymentResponse(BookingResponse bookingResponse)
        {
            var details = await _dbContext.BookingDetails.FindAsync(bookingResponse.BookingId);
            if (details == null) { 
            return new BookingDetails();
            }
            if (bookingResponse.ResponseValue)
            {
                details.PaymetSuccessful = true;
                details.IsCompleted = true;
                return details;
            }
            return details;
        }

        public async Task<BookingDetails> UpdateServiceResponse(BookingResponse bookingResponse)
        {
            var details = await _dbContext.BookingDetails.FindAsync(bookingResponse.BookingId);
            if (details == null)
            {
                return new BookingDetails();
            }
            if (bookingResponse.ResponseValue)
            {
                details.ServiceProviderResponse = true;
                details.BookingStatus = "Service Provider Successfully Confirmed your booking.";
               await _dbContext.SaveChangesAsync();
                return details;
            }
            return details;
        }
    }
}
