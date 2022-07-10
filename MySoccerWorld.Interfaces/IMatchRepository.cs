using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IMatchRepository
    {
        IEnumerable<Team> Teams();
        IEnumerable<Match> GetByTournament(int id);
        IEnumerable<Match> GetByTeam(int id);
        Match Get(int id);
        Match Details(int id);
        Task AddGoalAsync(Goal goal);
        void AddRange(ICollection<Match> matches);
        void AddAsist(Asist asist);
        void Delete(int id);
        void Update(Match match);
    }
}
