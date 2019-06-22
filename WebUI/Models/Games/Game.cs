using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Games
{
    public class Game
    {
        public int GameId { get; set; }
        [Required(ErrorMessage = "Please enter game's name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter game's description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter minumum number of players.")]
        public int MinPlayers { get; set; }
        [Required(ErrorMessage = "Please enter maximum number of players.")]
        public int MaxPlayers { get; set; }
        [DisplayName("Age")]
        [Required(ErrorMessage = "Please enter recommended age.")]
        public int RecommendedAge { get; set; }
    }
}