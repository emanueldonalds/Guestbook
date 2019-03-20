using Microsoft.Extensions.DependencyInjection;
using Novia.Guestbook.Infrastructure.Data.Ef;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Configuration
{
    public static class StorageConfigurator
    {
        static StorageConfigurator()
        {
            // This will only run once 
        }
        static public void SeedDatabase(IServiceProvider services)
        {
            try
            {
                var context = services.GetRequiredService<GuestbookDbContext>();
                GuestbookDbContextSeeder.SeedAsync(context);
            }
            catch (Exception ex)
            {
                // here so that we can step debug and could add some semantic meaning to the exception and retrow it 
                throw;
            }
        }
    }
}