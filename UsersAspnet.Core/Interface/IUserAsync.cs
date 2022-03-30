using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAspnet.Core.Models;

namespace UsersAspnet.Core.Interface
{
    public interface IUserAsync
    {
        Task<User> GetByIdAsync(int id);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<User> AddAsync(User entity);
        Task  UpdateAsync(int id);
        Task  DeleteAsync(int id);
    }
}
