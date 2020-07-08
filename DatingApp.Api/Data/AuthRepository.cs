using DatingApp.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DatingApp.Api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext dbContext)
        {
            _context = dbContext;
        }

        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
