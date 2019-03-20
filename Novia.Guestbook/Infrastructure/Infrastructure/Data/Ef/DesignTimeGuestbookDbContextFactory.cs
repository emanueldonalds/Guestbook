using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    public class DesignTimeGuestbookDbContextFactory :
        IDesignTimeDbContextFactory<GuestbookDbContext>
    {
        public GuestbookDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<GuestbookDbContext>();
            builder.UseSqlServer(connectionString);

            return new GuestbookDbContext(builder.Options);
        }
    }
}

