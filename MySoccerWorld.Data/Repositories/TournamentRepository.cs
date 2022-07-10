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
    public class TournamentRepository : ITournamentRepository
    {
        private readonly SoccerContext _context;
        public TournamentRepository(SoccerContext db)
        {
            _context = db;
        }
        public async Task<Tournament> DetailsAsync(int id) =>
                  await _context.Tournaments.Include(t => t.League).Include(t => t.Teams).ThenInclude(t => t.PlayerTeams).ThenInclude(p=>p.Player)
                                       .Include(t => t.Teams).ThenInclude(t => t.CoachTeams).ThenInclude(c => c.Coach).Include(t => t.Season)
                                       .Include(t => t.TournamentAwards).Include(t => t.BestPlayers).FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Tournament> GetAsync(int id) => await _context.Tournaments.Include(t=>t.Teams).FirstOrDefaultAsync(t=>t.Id==id);
        public IEnumerable<Tournament> GetAll() => _context.Tournaments.Include(t => t.Season).Include(t => t.Ratings).Include(t => t.League);
        public IEnumerable<Tournament> GetByLeague(int id) => _context.Tournaments.Include(t => t.Season).Where(t => t.LeagueId == id);
        public async Task UpdateAsync(Tournament tournament)
        {
            if (tournament.Id == 0) await _context.Tournaments.AddAsync(tournament);
            else _context.Entry(tournament).State = EntityState.Modified;
        }
        public async Task DeleteAsync(int id)
        {
            Tournament tournament = await _context.Tournaments.FindAsync(id);
            if (tournament != null) _context.Tournaments.Remove(tournament);
        }
    }
}
