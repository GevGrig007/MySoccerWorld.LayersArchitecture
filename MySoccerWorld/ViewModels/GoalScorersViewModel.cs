using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class GoalScorersViewModel
    {
        public Tournament Tournament { get; set; }
        public IEnumerable<PlayerTeam> PlayerTeams { get; set; }
        public IEnumerable<TournamentAward> TournamentAwards { get; set; }
    }
}
