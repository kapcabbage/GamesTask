using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int RecommendedAge { get; set; }
    }
}
