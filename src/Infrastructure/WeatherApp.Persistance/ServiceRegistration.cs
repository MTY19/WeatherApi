using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Persistance.Context;
using WeatherApp.Persistance.Repositories;

namespace WeatherApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
        }
    }
}

