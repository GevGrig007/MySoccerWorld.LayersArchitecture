using Microsoft.EntityFrameworkCore;
using MySoccerWorld.EF.Data;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Data.Repositories
{
    public class BestPlayerRepository : IBestPlayerRepository
    {
        private SoccerContext _context;
        public BestPlayerRepository(SoccerContext db)
        {
            _context = db;
        }       
        public async Task<BestPlayer> GetAsync(int id) =>
            await _context.BestPlayers.FindAsync(id);
        public IEnumerable<Player> GetPlayers() =>
            _context.Players.Include(p => p.PlayerTeams).OrderBy(p => p.Name);
        public Task<List<BestPlayer>> GetByTournamentAsync(int id) =>
            _context.BestPlayers.Include(b => b.PlayerTeam).ThenInclude(p => p.Player)
                                            .Include(b => b.PlayerTeam).ThenInclude(p => p.Team)
                                            .Where(p => p.TournamentId == id).ToListAsync();
        public Player GetClubsPlayer(int id) =>
              _context.Players.Include(p => p.PlayerTeams).ThenInclude(p => p.Season).FirstOrDefault(p => p.Id == id);
        public async Task Update(BestPlayer bestPlayer)
        {
            if (bestPlayer.Id == 0)
            {
                await _context.BestPlayers.AddAsync(bestPlayer);
            }
            else
            {
               _context.Entry(bestPlayer).State = EntityState.Modified;
            }
        }
    }
}
