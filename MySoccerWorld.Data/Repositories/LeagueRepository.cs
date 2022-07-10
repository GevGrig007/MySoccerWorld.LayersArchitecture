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
    public class LeagueRepository : ILeagueRepository
    {
        private readonly SoccerContext _context;
        public LeagueRepository(SoccerContext db)
        {
            _context = db;
        }
        public IEnumerable<League> GetAll() => _context.Leagues;
        public League Details(int id) =>
                      _context.Leagues.Include(l => l.Tournaments).ThenInclude(c => c.Season)
                                      .Include(l => l.Tournaments).ThenInclude(t => t.Ratings).FirstOrDefault(l => l.Id == id);
        public List<Tournament> Tournaments(int id) =>
                      _context.Tournaments.Include(t => t.Ratings).Where(t => t.LeagueId == id).ToList();
        public IEnumerable<PlayerTeam> GoalScorers(int id) =>
                       _context.PlayerTeams.Include(p => p.Team).Include(p => p.Player)
                                           .Include(p => p.Goals.Where(g => g.Match.Tournament.LeagueId == id));
        public IEnumerable<PlayerTeam> Asisters (int id) =>
                        _context.PlayerTeams.Include(p => p.Player).Include(p => p.Team)
                                            .Include(p => p.Asists.Where(g => g.Match.Tournament.LeagueId == id));
        public List<Match> Matches (int id) =>
                        _context.Matches.Where(m => m.Tournament.LeagueId == id).Include(m => m.Home).Include(m => m.Away).ToList();
        public IEnumerable<Rating> Ratings (int id) =>
                        _context.Ratings.Include(r => r.Team).Where(r => r.Tournament.LeagueId == id).Where(r => r.Tournament.Division == "1").ToList();
        public League Get(int id) => _context.Leagues.Find(id);
        public void Delete(int id)
        {
            League league = _context.Leagues.Find(id);
            if (league != null)
                _context.Leagues.Remove(league);
        }         
        public void Update(League league)
        {
            if (league.Id == 0)  _context.Leagues.Add(league);
            else  _context.Entry(league).State = EntityState.Modified;
        }
    }
}
