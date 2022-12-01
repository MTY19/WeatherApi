using System;
using System.Linq.Expressions;
using WeatherApi.Domain.Common;

namespace WeatherApp.Application.Interfaces.Repository
{
	public interface IGenericRepositoryAsync<T> where T:BaseEntity
	{
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid Id);

        Task<T> AddAsync(T entity);

        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}

