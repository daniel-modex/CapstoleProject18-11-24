using BookingApi.Data;
using BookingApi.Models;
using BookingApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Repository
{
    public class SummaryRepository : ISummaryRepository
    {

        private readonly BookingDBContext _dbContext;

        public SummaryRepository(BookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceCount> GetProfessionalSummary(string ProfessionalName)
        {
            return new ServiceCount()
            {
                ServiceName = ProfessionalName,
                Count = await _dbContext.BookingDetails.Where(x => x.ProfessionalName == ProfessionalName).CountAsync(),
            };
        }

        public async Task<ServiceCount> GetServiceSummary(string ServiceName)
        {
            return new ServiceCount()
            {
                ServiceName = ServiceName,
                Count = await _dbContext.BookingDetails.Where(x => x.ServiceProvided == ServiceName).CountAsync(),
            };
        }
    }
}
