using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Games
{
    public class Event
    {
        public int GameId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
    }
}