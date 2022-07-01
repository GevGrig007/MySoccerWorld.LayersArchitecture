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
    public class CoachRepository : ICoachRepository
    {
        private SoccerContext _context;
        public CoachRepository(SoccerContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            Coach coach = _context.Coaches.Find(id);
            if (coach != null)
                _context.Coaches.Remove(coach);
        }
        public Coach Details(int id)
        {
            return _context.Coaches.Include(c => c.CoachTeams).FirstOrDefault(c => c.Id == id);
        }
        public Coach Get(int? id)
        {
            return _context.Coaches.Include(p => p.Country).FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Coach> GetAll()
        {
            return _context.Coaches.Include(p => p.CoachTeams).Include(p => p.Country);
        }
        public IQueryable<Coach> Sort()
        {
            return _context.Coaches.Include(p => p.CoachTeams.OrderBy(p => p.Season)).ThenInclude(p => p.Team).Include(p => p.Country);
        }
        public void UpdateCoachTeams(CoachTeam coachTeam)
        {
            if (coachTeam.Id == 0)
            {
                _context.CoachTeams.Add(coachTeam);
            }
            else
            {
                _context.Entry(coachTeam).State = EntityState.Modified;
            }
        }
        public void Update(Coach coach)
        {
            if (coach.Id == 0)
            {
                _context.Coaches.Add(coach);
            }
            else
            {
                _context.Entry(coach).State = EntityState.Modified;
            }
        }

        public IEnumerable<Coach> GetByTournament(int id)
        {
            return _context.Coaches.Where(c => c.CoachTeams.Any(c => c.Team.Tournaments.Any(t => t.Id == id)));
        }
    }
}
