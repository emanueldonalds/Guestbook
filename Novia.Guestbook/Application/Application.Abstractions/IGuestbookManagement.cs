using Novia.Guestbook.Application.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Application.Abstractions
{
    public interface IGuestbookManagement
    {
        GuestbookDto Add(string sName);
        bool Remove(GuestbookDto theGuestbook);
        bool Modify(GuestbookDto theGuestbook);

        GuestbookDto FindById(int Id);

        IEnumerable<GuestbookDto> ListAll();

    }
}
