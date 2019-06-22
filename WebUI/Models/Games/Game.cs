using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebUI.Models.Games
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        [DisplayName("Age")]
        public int RecommendedAge { get; set; }
    }
}