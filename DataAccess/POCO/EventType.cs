using System;
using System.Collections.Generic;

namespace DataAccess.POCO
{
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}