using Microsoft.EntityFrameworkCore;
using Novia.Guestbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    using Guestbook = Novia.Guestbook.Domain.Entities.Guestbook;
    public abstract class EfGuestbookDbContext : EfDbContext
    {
        public EfGuestbookDbContext(DbContextOptions options) : base(options)
        {
        }
        protected EfGuestbookDbContext()
        {
        }
        public abstract DbSet<Guestbook> Guestbooks { get; set; }
        public abstract DbSet<GuestbookEntry> GuestbookEntries { get; set; }
    }
}

