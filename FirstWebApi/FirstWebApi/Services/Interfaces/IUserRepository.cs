using FirstWebApi.Models;

namespace FirstWebApi.Services.Interfaces
{
    public interface IUserRepository
    {
        User Validate(Login login);
    }
}
