using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Games.ViewModels
{
    public class GameDetailViewModel
    {
        public GameDetailViewModel()
        {
            Events = new List<Event>();
        }

        public Game Game { get; set; }
        public List<Event> Events { get; set; }
    }
}