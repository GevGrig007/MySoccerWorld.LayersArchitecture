using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IGoalRepository
    {
        IEnumerable<Goal> GetAll();
        IEnumerable<PlayerTeam> GetGoalsByTournament(int id);
        Goal Get(int id);
        Goal Details(int id);
        void Update(Goal goal);
        void Delete(int id);
    }
}
