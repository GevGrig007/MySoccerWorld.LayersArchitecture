using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface ILeagueRepository
    {
        IEnumerable<League> GetAll ();
        League Get (int id);
        League Details(int id);
        List<Tournament> Tournaments(int id);
        IEnumerable<PlayerTeam> GoalScorers(int id);
        IEnumerable<PlayerTeam> Asisters (int id);
        List<Match> Matches (int id);
        IEnumerable<Rating> Ratings(int id);
        void Update(League league);
        void Delete(int id);
    }
}
