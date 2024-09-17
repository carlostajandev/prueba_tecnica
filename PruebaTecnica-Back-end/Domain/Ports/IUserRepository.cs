using PruebaTecnica_Back_end.Domain.Entities;

namespace PruebaTecnica_Back_end.Domain.Ports
{

    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserRoleAsync(int idUser, string role);
    }
}
