using System;
using System.Collections.Generic;
using System.Text;

namespace Novia.Guestbook.Domain.Abstractions
{
    public interface IGuestbookEntry : IEntity<int>
    {
        string EmailAddress { get; set; }
        string Message { get; set; }

        DateTimeOffset DateTimeCreated { get; set; }
        IGuestbook BelongsTo { get; set; }
    }
}
