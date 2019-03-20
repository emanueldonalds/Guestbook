using Novia.Guestbook.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Domain.Entities
{
    public class Guestbook : Entity, IGuestbook
    {
        public string Name { get; set; }
        public IList<IGuestbookEntry> Entries
        { get; set; } = new List<IGuestbookEntry>();

        public Guestbook()
        {
            Name = "<Unknown>";
        }

        static public Guestbook CreateGuestbook(string sName)
        {
            Guestbook theNewGuestbook = new Guestbook { Name = sName };
            return theNewGuestbook;
        }

        public void AddEntry(IGuestbookEntry entry)
        {
            entry.BelongsTo=this;
            Entries.Add(entry);
        }
    }
}
