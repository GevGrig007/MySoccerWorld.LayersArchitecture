using Microsoft.EntityFrameworkCore;
using MySoccerWorld.EF.Data;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Data.Repositories
{
    public class AwardsRepository : IAwardsRepository
    {
        private SoccerContext _context;
        public AwardsRepository(SoccerContext context)
        {
            _context = context;
        }
        public IEnumerable<TournamentAward> GetByTournament(int id)
        {
            return _context.TournamentAwards.Include(a => a.PlayerTeam).ThenInclude(p => p.Player)
                                                  .Include(a => a.PlayerTeam).ThenInclude(p => p.Team)
                                                  .Include(a => a.CoachTeam).ThenInclude(p => p.Coach)
                                                  .Include(a => a.CoachTeam).ThenInclude(p => p.Team)
                                                  .Where(t => t.TournamentId == id).ToList();
        }
        public TournamentAward GetTournamentAward(int id)
        {
            return _context.TournamentAwards.Include(a => a.PlayerTeam).ThenInclude(p => p.Player)
                                                  .Include(a => a.PlayerTeam).ThenInclude(p => p.Team)
                                                  .Include(a => a.CoachTeam).ThenInclude(p => p.Coach)
                                                  .FirstOrDefault(t => t.Id == id);
        }
        public PlayerTeam GetPlayerAward(int? id)
        {
            var player = _context.Players.Include(p => p.PlayerTeams).ThenInclude(p => p.Season).FirstOrDefault(p => p.Id == id);
            return  player.PlayerTeams.Where(p => p.Season != null).FirstOrDefault();
        }
        public IEnumerable<Player> GetPlayerAwardStats()
        {
            return _context.Players.Where(p => p.PlayerTeams.Any(c => c.BestPlayers.Count > 0 || c.TournamentAwards.Count > 0))
                           .Include(p => p.PlayerTeams).ThenInclude(c => c.TournamentAwards)
                           .Include(p => p.PlayerTeams).ThenInclude(c => c.BestPlayers).Include(p => p.Country).ToList()
                           .OrderByDescending(c => c.PlayerTeams.Sum(c => c.BestPlayers.Count()));
        }
        public IEnumerable<Player> GetPlayerAwardStatsBySeason(int? id)
        {
            return _context.Players.Where(p => p.PlayerTeams.Any(c => c.BestPlayers.Where(c=>c.Tournament.SeasonId==id).Count() > 0 || c.TournamentAwards.Where(c => c.Tournament.SeasonId == id).Count() > 0))
                           .Include(p=>p.Country).ToList()
                           .OrderByDescending(c => c.PlayerTeams.Sum(c => c.BestPlayers.Count()));
        }

        public CoachTeam GetCoachAward(int? id)
        {
            var coach = _context.Coaches.Include(p => p.CoachTeams).ThenInclude(p => p.Season).FirstOrDefault(p => p.Id == id);
            return coach.CoachTeams.LastOrDefault();
        }
        public PlayerTeam GetNationalPlayerAward(int? id)
        {
            var player = _context.Players.Include(p => p.PlayerTeams).FirstOrDefault(p => p.Id == id);
            return player.PlayerTeams.Where(p => p.Season == null).LastOrDefault();
        }
        public IEnumerable<SeasonalAward> GetAwardsBySeason(int id)
        {
            return _context.SeasonalAwards.Include(s=>s.PlayerTeam).ThenInclude(p=>p.Team)
                                          .Include(s => s.PlayerTeam).ThenInclude(p => p.Player).ThenInclude(p=>p.Country)
                                          .Include(s => s.CoachTeam).ThenInclude(p => p.Team)
                                          .Include(s => s.CoachTeam).ThenInclude(p => p.Coach).ThenInclude(p => p.Country)
                                          .Where(s => s.SeasonId == id);
        }
        public IEnumerable<SeasonalAward> GetAwardsForSymbolicTeam(int id)
        {
            return _context.SeasonalAwards.Where(s=>s.AwardName==SeasonalAwardType.SeasonalStarting).Include(s => s.PlayerTeam).ThenInclude(p => p.Team)
                                          .Include(s => s.PlayerTeam).ThenInclude(p => p.Player).ThenInclude(p => p.Country)
                                          .Include(s => s.CoachTeam).ThenInclude(p => p.Team)
                                          .Include(s => s.CoachTeam).ThenInclude(p => p.Coach).ThenInclude(p => p.Country)
                                          .Where(s => s.SeasonId == id).OrderBy(c=>c.Id);
        }
        public void Update(TournamentAward award)
        {
            if (award.Id == 0)
            {
                _context.TournamentAwards.Add(award);
            }
            else
            {
                _context.Entry(award).State = EntityState.Modified;
            }
        }
        public void UpdateSeasonalAward(SeasonalAward award)
        {
            if (award.Id == 0)
            {
                _context.SeasonalAwards.Add(award);
            }
            else
            {
                _context.Entry(award).State = EntityState.Modified;
            }
        }
    }
}
