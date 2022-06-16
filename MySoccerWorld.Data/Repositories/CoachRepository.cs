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

        public CoachTeam Get(int? id)
        {
            var coach = _context.Coaches.Include(p => p.CoachTeams).ThenInclude(p => p.Season).FirstOrDefault(p => p.Id == id);
            return coach.CoachTeams.LastOrDefault();
        }

        public IEnumerable<Coach> GetAll()
        {
            return _context.Coaches.Include(p => p.CoachTeams).Include(p => p.Country);
        }
    }
}
