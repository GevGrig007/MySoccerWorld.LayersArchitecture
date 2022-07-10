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
    public class ShedulleRepository : IShedulleRepository
    {
        private readonly SoccerContext _context;

        public ShedulleRepository(SoccerContext context)
        {
            _context = context;
        }
        public Tournament TournamentForShedulle(int id) =>
                 _context.Tournaments.Include(t => t.League).Include(t => t.Teams).ThenInclude(t => t.PlayerTeams.OrderBy(p => p.Season))
                                     .Include(t => t.Teams).ThenInclude(t => t.CoachTeams).ThenInclude(c => c.Coach).Include(t => t.Season)
                                     .Include(t => t.TournamentAwards).Include(t=>t.BestPlayers).FirstOrDefault(x => x.Id == id);
    }
}
