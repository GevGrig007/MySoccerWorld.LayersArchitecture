using Microsoft.EntityFrameworkCore;
using MySoccerWorld.Data.Repositories;
using MySoccerWorld.EF.Data;
using MySoccerWorld.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Data
{
    public class DataManager : IDataManager
    {
        private readonly SoccerContext db;
        private IClubRepository clubRepository;
        private ICoachRepository coachRepository;
        private IGoalRepository goalRepository;
        private ILeagueRepository leagueRepository;
        private IMatchRepository matchRepository;
        private IPlayerRepository playerRepository;
        private IRatingRepository ratingRepository;
        private ISeasonRepository seasonRepository;
        private ITeamRepository teamRepository;
        private ITournamentRepository tournamentRepository;
        private IAwardsRepository awardsRepository;
        private IBestPlayerRepository bestPlayerRepository;
        private INationalRepository nationalRepository;
        private IPlayerTeamRepository playerTeamRepository;
        private IShedulleRepository shedulleRepository;
        public DataManager(SoccerContext context)
        {
            db = context;
        }
        public IClubRepository Clubs
        {
            get
            {
                if (clubRepository == null)
                    clubRepository = new ClubRepository(db);
                return clubRepository;
            }
        }
        public IShedulleRepository Shedulles
        {
            get
            {
                if (shedulleRepository == null)
                    shedulleRepository = new ShedulleRepository(db);
                return shedulleRepository;
            }
        }
        public ICoachRepository Coaches
        {
            get
            {
                if (coachRepository == null)
                    coachRepository = new CoachRepository(db);
                return coachRepository;
            }
        }
        public IBestPlayerRepository BestPlayers
        {
            get
            {
                if (bestPlayerRepository == null)
                    bestPlayerRepository = new BestPlayerRepository(db);
                return bestPlayerRepository;
            }
        }
        public IGoalRepository Goals
        {
            get
            {
                if (goalRepository == null)
                    goalRepository = new GoalRepository(db);
                return goalRepository;
            }
        }
        public ILeagueRepository Leagues
        {
            get
            {
                if (leagueRepository == null)
                    leagueRepository = new LeagueRepository(db);
                return leagueRepository;
            }
        }
        public IMatchRepository Matches
        {
            get
            {
                if (matchRepository == null)
                    matchRepository = new MatchRepository(db);
                return matchRepository;
            }
        }
        public IPlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }
        public IRatingRepository Ratings
        {
            get
            {
                if (ratingRepository == null)
                    ratingRepository = new RatingRepository(db);
                return ratingRepository;
            }
        }
        public ISeasonRepository Seasons
        {
            get
            {
                if (seasonRepository == null)
                    seasonRepository = new SeasonRepository(db);
                return seasonRepository;
            }
        }
        public ITeamRepository Teams
        {
            get
            {
                if (teamRepository == null)
                    teamRepository = new TeamRepository(db);
                return teamRepository;
            }
        }
        public ITournamentRepository Tournaments
        {
            get
            {
                if (tournamentRepository == null)
                    tournamentRepository = new TournamentRepository(db);
                return tournamentRepository;
            }
        }
        public INationalRepository Nationals
        {
            get
            {
                if (nationalRepository == null)
                    nationalRepository = new NationalRepository(db);
                return nationalRepository;
            }
        }
        public IPlayerTeamRepository PlayerTeams
        {
            get
            {
                if (playerTeamRepository == null)
                    playerTeamRepository = new PlayerTeamRepository(db);
                return playerTeamRepository;
            }
        }
        public IAwardsRepository Awards
        {
            get
            {
                if (awardsRepository == null)
                    awardsRepository = new AwardsRepository(db);
                return awardsRepository;
            }
        }
        public void Save() => db.SaveChanges();

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
