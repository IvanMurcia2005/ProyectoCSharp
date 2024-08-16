using Entity.Context;
using Entity.Model.Security;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Data.Interface;

namespace Data.Implements
{
    internal class UserData : IUserData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                    Id,
                    CONCAT(Name, ' - ', Description) AS TextoMostrar
                FROM
                    User
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM User WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });

        }

        public async Task<User> Save(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<User> GetByName(string username)
        {
            return await this.context.Users.AsNoTracking().Where(item => item.Username == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = @"SELECT * FROM Role ORDER BY Id ASC";
            return await this.context.QueryAsync<User>(sql);
        }

        public Task<IEnumerable<DataSelectDto>> GetDataSelects()
        {
            throw new NotImplementedException();
        }
    }
}