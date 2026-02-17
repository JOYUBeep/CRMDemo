using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IIdentity
    {
        public Task RegisterUser(RegisterUserDTO dto);
        Task <bool> LoginAsync(LoginDTO dto);
        Task<List<UserDetailDTO>> GetAllUsers();
        Task<UserDetailDTO> GetUserById(int id);
        Task UpdateUser(int id, UserUpdateDTO dto);
    }
}