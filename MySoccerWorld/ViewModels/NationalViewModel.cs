using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class NationalViewModel
    {
        public National Team { get; set; }
        public List<Match> Matches { get; set; }
        public List<Player> Players { get; set; }
        public ClubStats Stats { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
