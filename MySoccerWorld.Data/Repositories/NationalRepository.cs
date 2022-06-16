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
    public class NationalRepository : INationalRepository
    {
        private readonly SoccerContext _context;
        public NationalRepository(SoccerContext context)
        {
            _context = context;
        }
        public IQueryable<National> GetAll()
        {
            return _context.Nationals.Include(n => n.CoachTeams).ThenInclude(n => n.Coach);
        }
        public National Details(int id)
        {
            return _context.Nationals.Include(c => c.Ratings).ThenInclude(r => r.Tournament).ThenInclude(t => t.Season)
                                                           .Include(c => c.PlayerTeams).ThenInclude(p => p.Team)
                                                           .Include(c => c.CoachTeams).ThenInclude(c => c.Team).FirstOrDefault(c => c.Id == id);
        }
        public National Get(int id)
        {
            return _context.Nationals.Find(id);
        }
        public void Update(National national)
        {
            if (national.Id == 0)
            {
                _context.Nationals.Add(national);
            }
            else
            {
                _context.Entry(national).State = EntityState.Modified;
            }
        }
        public IEnumerable<National> Rating()
        {
            return _context.Nationals.Include(c => c.Ratings);
        }
    }
}
