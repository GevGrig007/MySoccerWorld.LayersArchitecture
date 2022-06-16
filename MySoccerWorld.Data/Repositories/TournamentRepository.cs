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
        public void Delete(int id)
        {
            Tournament tournament = _context.Tournaments.Find(id);
            if (tournament != null)
                _context.Tournaments.Remove(tournament);
        }
        public Tournament Details(int id)
        {
            return _context.Tournaments.Include(t => t.League)
                .Include(t => t.Teams).ThenInclude(t => t.PlayerTeams.OrderBy(p => p.Season))
                .Include(t => t.Season)
                .FirstOrDefault(x => x.Id == id);
        }
        public Tournament Get(int id)
        {
            return _context.Tournaments.Include(t=>t.Teams).FirstOrDefault(t=>t.Id==id);
        }

        public IEnumerable<Tournament> GetAll()
        {
            return _context.Tournaments.Include(t => t.Season).Include(t => t.Ratings).Include(t => t.League);
        }

        public IEnumerable<Tournament> GetByLeague(int id)
        {
            return _context.Tournaments.Include(t => t.Season).Where(t => t.LeagueId == id);
        }

        public void Update(Tournament tournament)
        {
            if (tournament.Id == 0)
            {
                _context.Tournaments.Add(tournament);
            }
            else
            {
                _context.Entry(tournament).State = EntityState.Modified;
            }
        }
    }
}
