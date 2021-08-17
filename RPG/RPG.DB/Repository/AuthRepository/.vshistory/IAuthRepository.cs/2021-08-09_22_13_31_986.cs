using RPG.Domain.Models;
using RPG.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Data.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Regester(User user,string password);
        Task<ServiceResponse<string>> Login(string userName,string password);
        Task<bool> UserExists(string userName);
    }
}
