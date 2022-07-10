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
    public class PlayerTeamRepository : IPlayerTeamRepository
    {
        private readonly SoccerContext _context;
        public PlayerTeamRepository(SoccerContext context)
        {
            _context = context;
        }
        public IEnumerable<PlayerTeam> GoalScorers(int id) =>
               _context.PlayerTeams.Include(p => p.Player).Include(p => p.Team).Include(p => p.Goals.Where(g => g.Match.TournamentId == id));
        public IEnumerable<PlayerTeam> Asisters(int id) =>
               _context.PlayerTeams.Include(p => p.Player).Include(p => p.Team).Include(p => p.Asists.Where(g => g.Match.TournamentId == id));
        public void Update(PlayerTeam playerTeam)
        {
            if (playerTeam.Id == 0) _context.PlayerTeams.Add(playerTeam);
            else _context.Entry(playerTeam).State = EntityState.Modified;
        }
    }
}
