using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Services
{
    public interface ITournamentService
    {
        List<TournamentTable> CalculatingTable(IEnumerable<Match> matches, ICollection<Team> teams);
        public List<TournamentGroup> Group8(Tournament tournament);
        public List<TournamentGroup> Group2(Tournament tournament);
        public List<TournamentGroup> Group4(Tournament tournament);
        public List<TournamentGroup> EuroGroup(Tournament tournament);
    }
}
