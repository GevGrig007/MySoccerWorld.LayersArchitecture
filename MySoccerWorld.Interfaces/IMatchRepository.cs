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
        void Update(Match match);
        void AddRange(ICollection<Match> matches);
        void Delete(int id);
        void Save();
        IEnumerable<Match> GetByTournament(int id);
        IEnumerable<Match> GetByTeam(int id);
        Match Get(int id);
        Match Details(int id);
        Task AddGoal(Goal goal);
        void AddAsist(Asist asist);
    }
}
