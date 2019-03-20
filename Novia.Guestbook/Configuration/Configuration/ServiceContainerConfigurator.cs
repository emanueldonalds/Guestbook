using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Novia.Guestbook.Application.Abstractions;
using Novia.Guestbook.Application.Services;
using Novia.Guestbook.Domain.Abstractions;
using Novia.Guestbook.Domain.Entities;
using Novia.Guestbook.Infrastructure.Data.Ef;
using Novia.Guestbook.Infrastructure.Data.Ef.Repositories;

namespace Novia.Guestbook.Configuration
{
    using Guestbook = Domain.Entities.Guestbook;

    static public class ServiceContainerConfigurator
    {
        static ServiceContainerConfigurator()
        {
            // This will only run once
        }

        static public void ConfigureServices(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<GuestbookDbContext>(options => options.UseSqlServer(connectionString))
                    .AddTransient<EfGuestbookDbContext, GuestbookDbContext>()
                    .AddTransient<IGuestbookRepository, GuestbookRepository>()
                    .AddTransient<IGuestbookManagement, GuestbookManagement>()
                    // Here we get a new entry with default constructor
                    .AddTransient<IGuestbookEntry, GuestbookEntry>()
                    .AddTransient<IGuestbook, Guestbook>((contex) =>
                    {
                        // And here we are using our guestbook factory                     
                        Guestbook entity = Guestbook.CreateGuestbook("<unknown diary>");
                        return entity;
                    });
        }
    }
}
