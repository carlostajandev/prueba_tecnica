using PruebaTecnica_Back_end.Domain.Entities;
using PruebaTecnica_Back_end.Domain.Ports;


namespace PruebaTecnica_Back_end.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);

        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }


        public async Task AssignRoleToUserAsync(int idUser, string role)
        {

            if (role != Roles.Admin && role != Roles.Supervisor && role != Roles.Employee)
            {
                throw new ArgumentException("Invalid role");
            }

            await _userRepository.UpdateUserRoleAsync(idUser, role);
        }

    }
}
