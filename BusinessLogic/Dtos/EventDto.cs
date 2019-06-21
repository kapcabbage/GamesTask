using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dtos
{
    public class EventDto
    {
        public string EventType { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
    }
}
