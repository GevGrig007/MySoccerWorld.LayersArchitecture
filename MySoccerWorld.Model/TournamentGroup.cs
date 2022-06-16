using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model
{
    public class TournamentGroup
    {
        public string Name { get; set; }
        public Tournament Tournament { get; set; }
        public List<Team> Teams { get; set; }
        public IEnumerable<Match> Matches { get; set; }
        public IEnumerable<TournamentTable> GroupStandings { get; set; }
    }
}
