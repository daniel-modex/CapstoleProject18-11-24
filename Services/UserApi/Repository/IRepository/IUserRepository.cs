using CommonLibrary;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> PutUser(User updateUser);
        Task<bool> PostUser(RegistrationRequestDTO registrationRequestDTO);
        Task<bool> DeleteUser(int id);
        Task<User> GetUserByUserName(string userName);




    }
}
