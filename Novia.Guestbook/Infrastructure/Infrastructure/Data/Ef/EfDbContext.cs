using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Infrastructure.Data.Ef
{
    public abstract class EfDbContext : DbContext, IDbContext
    {
        //
        // Summary:
        // Initializes a new instance of the Microsoft.EntityFrameworkCore.DbContext class
        // using the specified options. The Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbConte        xtOptionsBuilder)
         // method will still be called to allow further configuration of the options.
         //
         // Parameters:
         // options:
         // The options for this context.
         public EfDbContext(DbContextOptions options)
            : base(options)
         {
         }

        //
        // Summary:
        // Initializes a new instance of the Microsoft.EntityFrameworkCore.DbContext class.
        // The Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbConte        xtOptionsBuilder)
        // method will be called to configure the database (and other options) to be used
        // for this context.
        protected EfDbContext()
            : base()
        {
        }
    }
}

