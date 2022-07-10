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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SoccerContext _context;
        public PlayerRepository(SoccerContext db)
        {
            _context = db;
        }
        public Player Details(int id) =>
                     _context.Players.Include(p => p.PlayerTeams).ThenInclude(p => p.Team).ThenInclude(t=>t.Ratings)
                                     .ThenInclude(r=>r.Tournament).Include(p=>p.Country).Include(p => p.PlayerTeams).ThenInclude(p => p.Season)
                                     .Include(p => p.PlayerTeams).ThenInclude(p => p.Goals).ThenInclude(g=>g.Match).ThenInclude(m=>m.Tournament).ThenInclude(t=>t.Season)
                                     .Include(p => p.PlayerTeams).ThenInclude(p => p.Asists).ThenInclude(g => g.Match).ThenInclude(m => m.Tournament).ThenInclude(t => t.Season)
                                     .FirstOrDefault(p => p.Id == id);
        public List<Player> ClubPlayers(int id)
        {
            var players = _context.Players.Where(p=>p.PlayerTeams.Count>0).Include(p => p.PlayerTeams.OrderBy(p => p.Season)).ThenInclude(p => p.Player)
                          .Include(p => p.PlayerTeams).ThenInclude(p => p.Goals).Include(p => p.PlayerTeams).ThenInclude(p => p.Asists).ToList();
            return players.Where(p => p.PlayerTeams.LastOrDefault().TeamId == id).ToList();
        }
        public Player Get(int id) => _context.Players.Include(p => p.Country).FirstOrDefault(p => p.Id == id);
        public IEnumerable<Player> GetAll() => _context.Players.Include(p=>p.PlayerTeams).Include(p => p.Country);
        public IQueryable<Player> Sort() =>
                        _context.Players.Include(p => p.PlayerTeams.OrderBy(p => p.Season)).ThenInclude(p => p.Team).Include(p => p.Country);
        public List<Player> NationalPlayers(int id)
        {
            var players = _context.Players.Include(p => p.PlayerTeams).ThenInclude(p => p.Player).Include(p => p.PlayerTeams)
                                          .ThenInclude(p => p.Goals).Include(p => p.PlayerTeams).ThenInclude(p => p.Asists);
            return players.Where(p => p.PlayerTeams.Any(p=>p.TeamId == id)).ToList();
        }
        public List<Player> GetForNational(int id)
        {
            National national = _context.Nationals.Find(id);
            return _context.Players.Include(p => p.PlayerTeams).Where(p => p.Country.Name == national.Name).ToList();
        }
        public void Update(Player player)
        {
            if (player.Id == 0) _context.Players.Add(player);
            else _context.Entry(player).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Player player = _context.Players.Find(id);
            if (player != null)
                _context.Players.Remove(player);
        }
    }
}
