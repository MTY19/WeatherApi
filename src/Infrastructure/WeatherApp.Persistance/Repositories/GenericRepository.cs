using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Common;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Persistance.Context;

namespace WeatherApp.Persistance.Repositories
{
	public class GenericRepository<T>: IGenericRepositoryAsync<T> where T:BaseEntity
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Query()
        {
            return dbContext.Set<T>();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}

