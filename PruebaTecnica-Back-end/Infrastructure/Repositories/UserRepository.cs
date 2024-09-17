using Microsoft.EntityFrameworkCore;
using PruebaBackend.Infrastructure.Persistence;
using PruebaTecnica_Back_end.Domain.Entities;
using PruebaTecnica_Back_end.Domain.Ports;


namespace PruebaTecnica_Back_end.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDB _context;

        public UserRepository(TaskManagementDB context)
        {
            _context = context;
        }

        public UserRepository()
        {
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task EditUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateUserRoleAsync(int idUser, string role)
        {
            var user = await _context.Users.FindAsync(idUser);
            if (user != null)
            {
                user.Role = role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
