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
    public class ClubRepository : IClubRepository
    {
        private SoccerContext _context;
        public ClubRepository(SoccerContext db)
        {
            _context = db;
        }
        public async Task<Team> Get(int id) =>
               await _context.Teams.FindAsync(id);
        public Task<Club> Details(int id) =>
              _context.Clubs.Include(c => c.Ratings).ThenInclude(r => r.Tournament).ThenInclude(t => t.Season)
                            .Include(c => c.Country).Include(c => c.PlayerTeams).ThenInclude(p => p.Team)
                            .Include(c => c.CoachTeams).ThenInclude(c => c.Team).FirstOrDefaultAsync(c => c.Id == id);
        public IEnumerable<Club> GetAll() =>
             _context.Clubs.Include(c => c.Country);
        public IQueryable<Club> ClubSort() => 
            _context.Clubs.Include(c => c.Country).Include(c => c.CoachTeams).ThenInclude(c => c.Coach);
        public Task<List<Club>> Rating() =>
              _context.Clubs.Include(c => c.Ratings).Include(c => c.Country).ToListAsync();
        public List<Player> Players(int id)
        {
            var players =  _context.Players.Where(p=>p.PlayerTeams.Count>0).Include(p => p.Country).Include(p => p.PlayerTeams).ThenInclude(p => p.Team)
                                                .Include(p => p.PlayerTeams).ThenInclude(p => p.Player).ToList();
            var clubPlayers =  players.Where(p => p.PlayerTeams/*.OrderByDescending(pt => pt.SeasonId)*/.Last().TeamId == id);
            return clubPlayers.ToList();
        } 
        public IEnumerable<Country> Countries() =>
              _context.Countries;      
        public async Task Update(Club club)
        {
            if (club.Id == 0)
            {
                await _context.Teams.AddAsync(club);
            }
            else
            {
                _context.Entry(club).State = EntityState.Modified;
            }
        }
        public async Task Delete(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            _context.Remove(club);
        }
    }
}
