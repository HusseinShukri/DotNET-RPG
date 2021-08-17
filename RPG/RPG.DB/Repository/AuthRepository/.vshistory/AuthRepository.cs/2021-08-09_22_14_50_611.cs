using RPG.Data.Context;
using RPG.Domain.Models;
using RPG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<ServiceResponse<string>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> Regester(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
