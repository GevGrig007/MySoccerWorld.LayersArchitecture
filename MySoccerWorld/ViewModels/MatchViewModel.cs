using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class MatchViewModel
    {
        public Match Match { get; set; }
        public List<Player> HomePlayers { get; set; }
        public List<Player> AwayPlayers { get; set; }
    }
}
