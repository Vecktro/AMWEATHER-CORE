using AMWEATHER_CORE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMWEATHER_CORE.Context
{
    public class WeatherAppDbContext : DbContext
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options) : base(options)
        {

        }
        public WeatherAppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("devConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<User> User { get; set; }

        public DbSet<WeatherAuditory> WeatherAuditory { get; set; }        
    }
}
