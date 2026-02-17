using Application.DTO;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
public class IdentityRepos : IIdentity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public IdentityRepos(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        public async Task<bool> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName ?? dto.Email,
                dto.Password,
                dto.RememberMe,
                lockoutOnFailure: true
            );

            return result.Succeeded;
        }

        public async Task RegisterUser(RegisterUserDTO dto)
        {
           var newUser = new User()
           {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
           };

           await _userManager.CreateAsync(newUser,dto.Password);
        }
        public async  Task<List<UserDetailDTO>> GetAllUsers()
        {
            var users = await _userManager.Users
            .OrderBy(u => u.Id)
            .ThenBy(u => u.FullName)
            .ToListAsync();

            return users.Select(u => new UserDetailDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName,
                EmailConfirmed = u.EmailConfirmed,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            }).ToList();
        }
        public async Task<UserDetailDTO> GetUserById(int id)
        {
            var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            return new UserDetailDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName, 
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        public async Task UpdateUser(int id, UserUpdateDTO dto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {id} not found.");
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;
            user.UserName = dto.UserName;
            user.UpdatedAt = DateTime.Now;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var errors = string.Join(", ", updateResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to update user: {errors}");
            }
        }
    }
}