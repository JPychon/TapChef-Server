using Microsoft.EntityFrameworkCore;
using TapChef_Backend.Data;
using TapChef_Backend.Interfaces;
using TapChef_Backend.Utility;

namespace TapChef_Backend.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<Response<TEntity>> GetByIdAsync(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return new Response<TEntity>
                {
                    Success = false,
                    Message = $"Entity with ID {id} not found."
                };
            }
            return new Response<TEntity>
            {
                Data = entity,
                Success = true
            };
        }

        public async Task<Response<IEnumerable<TEntity>>> GetAllAsync()
        {
            var entities = await Context.Set<TEntity>().ToListAsync();
            return new Response<IEnumerable<TEntity>>
            {
                Data = entities,
                Success = true
            };
        }

        public async Task<Response<TEntity>> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                return new Response<TEntity>
                {
                    Success = false,
                    Message = "Entity cannot be null."
                };
            }

            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return new Response<TEntity>
            {
                Data = entity,
                Success = true
            };
        }

        public async Task<Response<TEntity>> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                return new Response<TEntity>
                {
                    Success = false,
                    Message = "Entity cannot be null."
                };
            }

            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();

            return new Response<TEntity>
            {
                Data = entity,
                Success = true
            };
        }

        public async Task<Response<TEntity>> DeleteAsync(int id)
        {
            var entity = await Context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return new Response<TEntity>
                {
                    Success = false,
                    Message = $"Entity with ID {id} not found."
                };
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();

            return new Response<TEntity>
            {
                Data = entity,
                Success = true
            };
        }
    }
}