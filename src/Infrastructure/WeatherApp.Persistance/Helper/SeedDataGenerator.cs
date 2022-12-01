using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherApi.Domain.Entities;
using WeatherApp.Persistance.Context;

namespace WeatherApp.Persistance.Helper
{
    public class SeedDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any board games.
                if (context.Users.Any())
                {
                    return;   // Data was already seeded
                }
                context.Users.AddRange(

                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Username = "Tahir",
                        Password = "123",
                        CreaateDate = DateTime.Now
                    },
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Username = "Yilmaz",
                        Password = "123",
                        CreaateDate = DateTime.Now
                    });

                context.SaveChanges();
            }
        }
    }
}

