using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RPG.Data.Context;
using RPG.Domain.Entities;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Data.Repository.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            ServiceResponse<string> response = new();
            User user = await _dataContext.User.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(userName.ToLower()));
            if (user == null)
            {
                response.Message = "User Not Found";
                response.Success = false;
            }
            if (!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
            {
                response.Message = "Password not Correct";
                response.Success = false;
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Regester(User user, string password)
        {
            ServiceResponse<int> serviceResponse = new();
            if (UserExists(user.Name).Result)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User already exists.";
                return serviceResponse;
            }

            CreatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dataContext.User.AddAsync(user);
            var success = await SaveChanges();

            if (success) { serviceResponse.Data = user.Id; }
            if (!success) { serviceResponse.Success = false; serviceResponse.Message = "Some Error"; }

            return serviceResponse;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _dataContext.User.AnyAsync(u => u.Name.ToLower().Equals(userName.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SaveChanges()
        {

            return _dataContext.SaveChanges() > 0;
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoder.UTF8);
            return string.Empty;
        }
    }
}
