using Homework4.Business.DTOs;

namespace Homework4.Business.Abstracts
{
    public interface IJwtService
    {
        TokenDTO Authenticate(UserDTO user);
    }
}