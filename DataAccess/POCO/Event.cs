using System;
using System.Collections.Generic;

namespace DataAccess.POCO
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int GameId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Game Game { get; set; }
    }
}