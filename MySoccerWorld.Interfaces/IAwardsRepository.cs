using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IAwardsRepository
    {
        IEnumerable<TournamentAward> GetByTournament(int id);
        void Update(TournamentAward award);
        PlayerTeam GetPlayerAward(int? id);
    }
}
