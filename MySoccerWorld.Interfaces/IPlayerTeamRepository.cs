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
        IEnumerable<PlayerTeam> GoalScorers(int id);
        IEnumerable<PlayerTeam> Asisters(int id);
        void Update(PlayerTeam playerTeam);
    }
}
