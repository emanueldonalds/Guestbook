using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Novia.Guestbook.Configuration;
using Novia.Guestbook.Domain.Abstractions;
using Novia.Guestbook.Domain.Entities;
using Novia.Guestbook.Infrastructure.Data.Ef;
using Novia.Guestbook.Infrastructure.Data.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Novia.Guestbook.Presentation.Console
{
    using Guestbook = Novia.Guestbook.Domain.Entities.Guestbook;
    using GuestbookEntry = Novia.Guestbook.Domain.Entities.GuestbookEntry;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            ServiceContainerConfigurator.ConfigureServices(
              configuration.GetConnectionString("DefaultConnection"), services);

            
        }
    }
}
