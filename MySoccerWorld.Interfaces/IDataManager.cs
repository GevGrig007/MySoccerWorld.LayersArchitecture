using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IDataManager : IDisposable
    {
        IClubRepository Clubs { get; }
        ICoachRepository Coaches { get; }
        IBestPlayerRepository BestPlayers { get; }
        IGoalRepository Goals { get; }
        ILeagueRepository Leagues { get; }
        IMatchRepository Matches { get; }
        IPlayerRepository Players { get; }
        IRatingRepository Ratings { get; }
        ISeasonRepository Seasons { get; }
        ITeamRepository Teams { get; }
        ITournamentRepository Tournaments { get; }
        INationalRepository Nationals { get; }
        IPlayerTeamRepository PlayerTeams { get; }
        IAwardsRepository Awards { get; }
        void Save();
    }
}
