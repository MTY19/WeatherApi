using System;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities;

namespace WeatherApp.Persistance.Context
{
	public class ApplicationDbContext:DbContext
	{

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

