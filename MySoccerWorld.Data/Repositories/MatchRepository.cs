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
    public class MatchRepository : IMatchRepository
    {
        private readonly SoccerContext _context;
        public MatchRepository (SoccerContext db)
        {
            _context = db;
        }
        public async Task AddGoalAsync(Goal goal) => await _context.Goals.AddAsync(goal);
        public void AddRange(ICollection<Match> matches) => _context.Matches.AddRange(matches);
        public void AddAsist(Asist asist) => _context.Asists.AddRangeAsync(asist);
        public Match Details(int id) =>
                            _context.Matches.Include(m => m.Home).Include(m => m.Away)
                            .Include(m => m.Tournament).ThenInclude(m => m.League).FirstOrDefault(m => m.Id == id);
        public Match Get(int id) =>  _context.Matches.Find(id);
        public IEnumerable<Match> GetByTournament(int id) =>
                          _context.Matches.Where(x => x.TournamentId == id).Include(m => m.Goals).ThenInclude(p => p.PlayerTeam).ThenInclude(pt => pt.Player)
                                          .Include(m => m.Asists).ThenInclude(p => p.PlayerTeam).ThenInclude(pt => pt.Player).ToList();
        public IEnumerable<Match> GetByTeam(int id) =>
                          _context.Matches.Include(m => m.Tournament).ThenInclude(t => t.League).Include(m => m.Home).Include(m => m.Away)
                                          .Include(m => m.Goals).ThenInclude(g => g.PlayerTeam).ThenInclude(p => p.Player)
                                          .Include(m => m.Asists).ThenInclude(g => g.PlayerTeam).ThenInclude(p => p.Player)
                                          .Where(m => m.HomeTeam == id || m.AwayTeam == id).ToList();
        public IEnumerable<Team> Teams() => _context.Teams;
        public void Delete(int id)
        {
            Match match = _context.Matches.Find(id);
            if (match != null)
                _context.Matches.Remove(match);
        }
        public void Update(Match match)
        {
            if (match.Id == 0)  _context.Matches.Add(match);
            else  _context.Entry(match).State = EntityState.Modified;
        }      
    }
}
