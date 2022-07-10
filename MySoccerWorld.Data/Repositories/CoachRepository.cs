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
        private readonly SoccerContext _context;
        public CoachRepository(SoccerContext context)
        {
            _context = context;
        }
        public Coach Details(int id) =>
                     _context.Coaches.Include(c => c.CoachTeams).FirstOrDefault(c => c.Id == id);
        public Coach Get(int? id) =>
                     _context.Coaches.Include(p => p.Country).FirstOrDefault(p => p.Id == id);

        public IEnumerable<Coach> GetAll() =>
                     _context.Coaches.Include(p => p.CoachTeams).Include(p => p.Country);
        public IQueryable<Coach> Sort()=>
                     _context.Coaches.Include(p => p.CoachTeams.OrderBy(p => p.Season)).ThenInclude(p => p.Team).Include(p => p.Country);
        public IEnumerable<Coach> GetByTournament(int id) =>
                     _context.Coaches.Where(c => c.CoachTeams.Any(c => c.Team.Tournaments.Any(t => t.Id == id)));
        public void Update(Coach coach)
        {
            if (coach.Id == 0)   _context.Coaches.Add(coach);
            else  _context.Entry(coach).State = EntityState.Modified;
        }
        public void UpdateCoachTeams(CoachTeam coachTeam)
        {
            if (coachTeam.Id == 0)  _context.CoachTeams.Add(coachTeam);
            else  _context.Entry(coachTeam).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Coach coach = _context.Coaches.Find(id);
            if (coach != null)
                _context.Coaches.Remove(coach);
        }
    }
}
