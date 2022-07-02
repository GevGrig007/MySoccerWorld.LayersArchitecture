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
        TournamentAward GetTournamentAward(int id);
        IEnumerable<SeasonalAward> GetAwardsBySeason(int id);
        void Update(TournamentAward award);
        void UpdateSeasonalAward(SeasonalAward award);
        PlayerTeam GetPlayerAward(int? id);
        CoachTeam GetCoachAward(int? id);
        PlayerTeam GetNationalPlayerAward(int? id);
    }
}
