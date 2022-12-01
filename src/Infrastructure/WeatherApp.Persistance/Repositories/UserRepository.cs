using System;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Persistance.Context;

namespace WeatherApp.Persistance.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

