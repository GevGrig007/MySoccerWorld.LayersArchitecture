﻿using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class EuroCupViewModel
    {
        public Tournament Tournament { get; set; }
        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
        public IEnumerable<PlayerTeam> Goals { get; set; }
        public IEnumerable<PlayerTeam> Asists { get; set; }
        public IEnumerable<BestPlayer> BestPlayer { get; set; }
        public List<TournamentGroup> Groups { get; set; }
    }
}
