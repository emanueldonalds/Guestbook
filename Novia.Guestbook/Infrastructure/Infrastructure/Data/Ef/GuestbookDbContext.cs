using Microsoft.EntityFrameworkCore;
using Novia.Guestbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    using Guestbook = Novia.Guestbook.Domain.Entities.Guestbook;
    public class GuestbookDbContext : EfGuestbookDbContext
    {
        public GuestbookDbContext(DbContextOptions<GuestbookDbContext> options)
        : base(options)
        {

        }
        public override DbSet<Guestbook> Guestbooks { get; set; }
        public override DbSet<GuestbookEntry> GuestbookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guestbook>()
                .HasMany(b => (IList<GuestbookEntry>)b.Entries)
                .WithOne(e => (Guestbook)e.BelongsTo);

            modelBuilder.Entity<GuestbookEntry>()
                .HasOne(e => (Guestbook)e.BelongsTo)
                .WithMany(b => (IList<GuestbookEntry>)b.Entries);
        }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();
            // dispatch events only if save was successful
            // Here we will have a event dispatcher later on
            return result;
        }
    }
}
