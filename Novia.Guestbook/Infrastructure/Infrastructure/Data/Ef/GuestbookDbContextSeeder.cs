using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Novia.Guestbook.Domain.Abstractions;
using Novia.Guestbook.Domain.Entities;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    using Guestbook = Domain.Entities.Guestbook;
    public static class GuestbookDbContextSeeder
    {
        public static int SeedAsync(GuestbookDbContext context)
        {
            // Use the Migrate method to automatically create the database and migrat if needed 
            context.Database.EnsureCreated();

            if (context.Guestbooks.Count() == 0)
            {
                // we could also check for some specific instances and behave accordingly to the result. 
                Guestbook guestbook = new Guestbook { Name = "Novia guestbook" };
                IGuestbookEntry firstEntry = new GuestbookEntry
                {
                    Message = "Welcome to Novia!"
                };
                guestbook.AddEntry(firstEntry);
                IGuestbookEntry secondEntry = new GuestbookEntry
                {
                    Message = "IT profile salutes you."
                };
                guestbook.AddEntry(secondEntry);

                context.Guestbooks.Add(guestbook);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}