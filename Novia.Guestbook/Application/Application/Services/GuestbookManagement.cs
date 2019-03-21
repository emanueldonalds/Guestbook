
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Novia.Guestbook.Application.Abstractions;
using Novia.Guestbook.Application.Abstractions.Dtos;
using Novia.Guestbook.Domain.Abstractions;

namespace   Novia.Guestbook.Application.Services
{
    using Guestbook = Domain.Entities.Guestbook;
    public class GuestbookManagement : IGuestbookManagement
    {
        private IGuestbookRepository mGuestbookRepository;

        public GuestbookManagement(IGuestbookRepository guestbookRepository)
        {
            mGuestbookRepository = guestbookRepository;
        }

        public GuestbookDto Add(string sName)
        {
            IGuestbook newBook = Guestbook.CreateGuestbook(sName);
            newBook = mGuestbookRepository.Add(newBook); // engine code with storage

            //Mapping domain object to ui object
            GuestbookDto newBookDto = new GuestbookDto
            {
                Name = newBook.Name,
                Id = newBook.Id
            };

            return newBookDto;
        }

        public IEnumerable<GuestbookDto> ListAll()
        {
            var theGuestbooks = mGuestbookRepository.ListAll();
            // Mapping all domain objects to ui objects 
            List<GuestbookDto> theGuestbookDtos = theGuestbooks.Select(entry => 
                new GuestbookDto { Name = entry.Name, Id=entry.Id } ).ToList();
            return theGuestbookDtos;
        }

        public GuestbookDto FindById(int Id)
        {
            IGuestbook theGuestbook = mGuestbookRepository.GetById(Id);

            if (theGuestbook != null)
            {
                GuestbookDto theGuestbookDto = new GuestbookDto
                {
                    Name = theGuestbook.Name,
                    Id = theGuestbook.Id
                };

                return theGuestbookDto;
            }

            return null;
        }

        public bool Modify(GuestbookDto theGuestbook)
        {
            IGuestbook theBookToModify = mGuestbookRepository.GetById(theGuestbook.Id);

            if (theBookToModify != null)
            {
                // Mapping all ui objects to domain objects
                theBookToModify.Name = theGuestbook.Name;
                // fill in the guestbookentry list!
                mGuestbookRepository.Update(theBookToModify);

                return true;
            }

            return false;
            }

        public bool Remove(GuestbookDto theGuestbook)
        {
            throw new NotImplementedException();
        }
    }
}
