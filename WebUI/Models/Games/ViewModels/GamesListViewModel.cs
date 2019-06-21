using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Games
{
    public class GamesListViewModel
    {
        public GamesListViewModel()
        {
            Games = new List<Game>();
        }
        public List<Game> Games { get; set; } 
    }
}