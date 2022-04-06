using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsersAspnet.Core.Context;
using UsersAspnet.Core.Interface;
using UsersAspnet.Core.Models;

namespace UsersAspnet.Core.Service
{
    public class UserService : IUserAsync
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddAsync(User entity)
        {
            await _dbContext.Set<User>().AddAsync(entity);
            await   _dbContext.SaveChangesAsync();
            return entity;           
        }

        public  async Task DeleteAsync(int id)
        {
            var user = _dbContext.Set<User>().FindAsync(id);
            _dbContext.Remove(user);
           await  _dbContext.SaveChangesAsync();
        }

        public  async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public async Task UpdateAsync(int id)
        {
            var user = _dbContext.Set<User>().FindAsync(id);
            _dbContext.Update(user).State=EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
