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
        TournamentAward GetTournamentAward(int id);
        IEnumerable<TournamentAward> GetByTournament(int id);
        IEnumerable<SeasonalAward> GetAwardsBySeason(int id);       
        PlayerTeam GetPlayerAward(int? id);
        PlayerTeam GetNationalPlayerAward(int? id);
        CoachTeam GetCoachAward(int? id);
        IEnumerable<Player> GetPlayerAwardStats();
        IEnumerable<Player> GetPlayerAwardStatsBySeason(int? id);
        IEnumerable<SeasonalAward> GetAwardsForSymbolicTeam(int id);
        void Update(TournamentAward award);
        void UpdateSeasonalAward(SeasonalAward award);
    }
}
