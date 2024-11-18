using CommonLibrary;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Repository.IRepository;

namespace UserApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext _dbContext;
        public UserRepository(UserDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await _dbContext.Users.Select(x =>
                        new UserDTO
                        {
                            Id = x.Id,
                            Name = x.Name,
                            UserName = x.UserName,
                            Address = x.Address,
                            Email = x.Email,
                            Phone = x.Phone,
                            ProfilePic = x.ProfilePic,
                        }).ToListAsync();
                return users;
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null)
                {
                    return new User();
                }
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
                if (user == null)
                {
                    return new User();
                }
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostUser(RegistrationRequestDTO registrationRequestDTO)
        {
            try
            {
                var user = new User()
                {
                    UserName = registrationRequestDTO.UserName,
                    Email = registrationRequestDTO.Email,
                    Phone = registrationRequestDTO.Phone,
                    Name = registrationRequestDTO.Name,
                };
                _dbContext.Add(user);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<User> PutUser(User updatedUser)
        {
            try
            {
                var user = await GetUser(updatedUser.Id);
                if (user == null)
                {
                    return new User();
                }

                user.Address = updatedUser.Address;
                user.Gender = updatedUser.Gender;
                user.ProfilePic = updatedUser.ProfilePic;
                user.DOB = updatedUser.DOB;
                user.City = updatedUser.City;

                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
