using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Novia.Guestbook.Domain.Abstractions;
using Novia.Guestbook.Domain.Entities;
using Novia.Guestbook.Infrastructure.Data.Ef;

namespace Novia.Guestbook.Presentation.Console
{
    using Console = System.Console;
    using Guestbook = Novia.Guestbook.Domain.Entities.Guestbook;

    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            IEntity<int> theEntity = new Guestbook();
            Console.WriteLine(theEntity.ToString());
            //Console.WriteLine(theEntity.IsTransient().ToString());
            Entity theOtherEntity = new Guestbook();

            Console.WriteLine(theOtherEntity.IsTransient().ToString());

            // #2 static factory 
            Entity theThirdEntity = Guestbook.CreateGuestbook("novia visitor book");
            ////////////////////////
            IGuestbook theBook = Guestbook.CreateGuestbook("visit book");

            IGuestbookEntry theFirstEntry = new GuestbookEntry();
            IGuestbookEntry theSecondEntry = new GuestbookEntry();

            // --------------------------------
            theBook.AddEntry(theFirstEntry);
            theBook.AddEntry(theSecondEntry);

            // --------------------------------
            ///*/
            
            ////////////////////////
            var serviceCollection = new ServiceCollection();

            var bootStrapper = new Startup();
            bootStrapper.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (EfGuestbookDbContext theContext = serviceProvider.GetService<EfGuestbookDbContext>())
            {
                ////////////////////////
                // hard work
                // The transient objects
                IGuestbook guestbook = serviceProvider.GetService<IGuestbook>();
                guestbook.Name = "Novia";

                IGuestbookEntry guestbookEntry = null;

                //#1
                guestbookEntry = serviceProvider.GetService<IGuestbookEntry>();
                guestbook.AddEntry(guestbookEntry);

                //#2
                guestbookEntry = serviceProvider.GetService<IGuestbookEntry>();
                guestbookEntry.Message = "Testing entry.";
                guestbook.AddEntry(guestbookEntry);


                // Add the transient object to a repository, which knows how to store
                IGuestbookRepository theBookRepository = serviceProvider.GetService<IGuestbookRepository>();
                theBookRepository.Add(guestbook);

                //-------
                IGuestbook theBook = theBookRepository.GetById(3);
                //IGuestbook theBook = theBookRepository.ListAll()
                //    .ToList() // tuns the sql
                //    .Where(theIteratorBook => theIteratorBook.Name == "Novia").FirstOrDefault();

                theBook.Name = "Novia2";

                theBookRepository.Update(theBook as Guestbook);

                //-------

                ////////////////////////

                // Commit to the database
                theContext.SaveChanges();
            }




        }
    }
}
