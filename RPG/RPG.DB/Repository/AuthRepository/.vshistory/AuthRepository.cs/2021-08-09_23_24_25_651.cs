using RPG.Data.Context;
using RPG.Domain.Models;
using RPG.Domain.Response;
using System;
using System.Threading.Tasks;

namespace RPG.Data.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;

        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Regester(User user, string password)
        {
            CreatePasswordHah(password, out byte[] passwordSalt, out byte[] passwordHash);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.User.AddAsync(user);
            var success = await SaveChanges();
            if (success) { }
            if (!success) { }
        }

        public async Task<bool> UserExists(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {

            return _dataContext.SaveChanges() > 0;
        }

        private void CreatePasswordHah(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
