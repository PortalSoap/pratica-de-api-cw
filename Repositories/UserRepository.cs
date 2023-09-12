using Microsoft.EntityFrameworkCore;
using teste_de_api.Data;
using teste_de_api.Models;
using teste_de_api.Repositories.Interfaces;

namespace teste_de_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel target = await GetById(id);

            if(target == null)
            {
                throw new Exception($"ID de Usuário: {id} não foi encontrado.");
            }

            target.Name = user.Name;
            target.Email = user.Email;

            _dbContext.Users.Update(target);
            await _dbContext.SaveChangesAsync();

            return target;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel target = await GetById(id);

            if(target == null)
            {
                throw new Exception($"ID de Usuário: {id} não foi encontrado.");
            }

            _dbContext.Users.Remove(target);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}