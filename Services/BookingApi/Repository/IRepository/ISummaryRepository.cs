using BookingApi.Models;

namespace BookingApi.Repository.IRepository
{
    public interface ISummaryRepository
    {
        Task<ServiceCount> GetServiceSummary(string ServiceName);
        Task<ServiceCount> GetProfessionalSummary(string ProfessionalName);
    }
}
