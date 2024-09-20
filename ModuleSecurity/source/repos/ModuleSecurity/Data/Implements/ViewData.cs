using Entity.Context;
using Entity.Model.Security;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entity.Dto;
using Data.Interface;

namespace Data.Implements
{
    public class ViewData : IViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDBContext context, IConfiguration configuration)
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
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                    Id,
                    CONCAT(Name, ' - ', Description) AS TextoMostrar
                FROM
                    view
                WHERE Deleted_at IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM View WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });

        }

        public async Task<View> Save(View entity)
        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<View> GetByName(string description)
        {
            return await this.context.Views.AsNoTracking().Where(item => item.Description == description).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<View>> GetAll()
        {
            var sql = @"SELECT * FROM View ORDER BY Id ASC";
            return await this.context.QueryAsync<View>(sql);
        }

        public async Task<IEnumerable<View>> SelectAll()
        {
            var sql = @"SELECT * FROM View  WHERE DeletedAt IS NULL AND state = 1
            ORDER BY Id ASC";

            try
            {
                return await this.context.QueryAsync<View>(sql);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al ejecutar la consulta ", ex);
            }
        }
    }
}
