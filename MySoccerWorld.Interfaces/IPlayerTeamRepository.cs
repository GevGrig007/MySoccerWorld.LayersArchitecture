using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IPlayerTeamRepository
    {
        void Update(PlayerTeam playerTeam);
        IEnumerable<PlayerTeam> GoalScorers(int id);
        IEnumerable<PlayerTeam> Asisters(int id);
    }
}
