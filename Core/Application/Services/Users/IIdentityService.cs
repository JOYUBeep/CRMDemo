using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Identity
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(LoginDTO dto);
        Task RegisterUser(RegisterUserDTO dto);
        Task<List<UserDetailDTO>> GetAllUsers();
        Task<UserDetailDTO> GetUserById(int id);
        Task UpdateUser(int id, UserUpdateDTO dto);
    }
}

   