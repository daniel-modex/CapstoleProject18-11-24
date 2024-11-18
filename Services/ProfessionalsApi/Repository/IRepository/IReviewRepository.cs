using ProfessionalsApi.Models;

namespace ProfessionalsApi.Repository.IRepository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Reviews>> GetReviewsByProfessional(string username);
        Task<Reviews> GetReviewById(int id);
        Task<bool> PostReview(Reviews review);

    }
}
