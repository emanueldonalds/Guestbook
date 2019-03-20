using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Domain.Abstractions
{
    public interface IGuestbook: IAggregateRoot<int>

    {
        string Name { get; set; }
        IList<IGuestbookEntry> Entries { get; set; }

        void AddEntry(IGuestbookEntry entry);

    }
}
