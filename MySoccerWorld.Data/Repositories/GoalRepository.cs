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
    public class GoalRepository : IGoalRepository
    {
        private readonly SoccerContext _context;
        public GoalRepository(SoccerContext db)
        {
            _context = db;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Goal Details(int id)
        {
            throw new NotImplementedException();
        }
        public Goal Get(int id)
        {
            return _context.Goals.Find(id);
        }
        public IEnumerable<Goal> GetAll()
        {
            return _context.Goals;
        }

        public IEnumerable<PlayerTeam> GetGoalsByTournament(int id)
        {
            return _context.PlayerTeams.Include(p => p.Player).Include(p => p.Team)
                                             .Include(p => p.Player).ThenInclude(p => p.Country)
                                             .Include(p => p.Goals.Where(g => g.Match.TournamentId == id))
                                             .Include(p => p.Asists.Where(g => g.Match.TournamentId == id)).ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Goal goal)
        {
            if (goal.Id == 0)
            {
                _context.Goals.Add(goal);
            }
            else
            {
                _context.Entry(goal).State = EntityState.Modified;
            }
        }
    }
}
