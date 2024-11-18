using CommonLibrary;
using ProfessionalsApi.Controllers;
using ProfessionalsApi.Models;

namespace ProfessionalsApi.Repository.IRepository
{
    public interface IProfessionalRepository
    {
        Task<bool> PostProfessional(RegistrationRequestDTO registrationRequestDTO);
        Task<Professionals> GetProfessionalByUserName(string userName);
        Task<Professionals> PutProfessional(int id, UpdateProfile updateProfile);
        Task<bool> ChangeStatus(int id, bool status);
        Task<bool> ConfirmResponse(ConfirmService confirm);
        Task<bool> DeleteProfessional(int id);
        Task<IEnumerable<Professionals>> GetAllProfessionals();
        Task<IEnumerable<Professionals>> GetProfessionalsByDomain(string domain);
        Task<Professionals> GetProfessional(int id);
    }
}
