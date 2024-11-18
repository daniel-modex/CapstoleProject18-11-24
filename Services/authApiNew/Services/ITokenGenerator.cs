using authApiNew.models;

namespace authApiNew.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
