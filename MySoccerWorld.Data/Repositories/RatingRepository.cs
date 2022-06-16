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
    public class RatingRepository : IRatingRepository
    {
        private readonly SoccerContext _context;
        public RatingRepository(SoccerContext db)
        {
            _context = db;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Rating Details(int id)
        {
            throw new NotImplementedException();
        }
        public Rating Get(int id)
        {
            return _context.Ratings.Find(id);
        }
        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings;
        }
        public IEnumerable<Player> TopScorers()
        {
            return _context.Players.Include(p => p.Country).Include(p => p.PlayerTeams)
                                                                  .ThenInclude(p => p.Goals)
                                                                  .Include(p => p.PlayerTeams)
                                                                  .ThenInclude(p => p.Asists)
                                                                  .ToList();
        }
        public IEnumerable<Player> SeasonalScorers(int id)
        {
            return _context.Players.Include(p => p.Country).Include(p => p.PlayerTeams)
                                                                  .ThenInclude(p => p.Goals.Where(g => g.Match.Tournament.SeasonId == id))
                                                                  .Include(p => p.PlayerTeams)
                                                                  .ThenInclude(p => p.Asists.Where(g => g.Match.Tournament.SeasonId == id))
                                                                  .ToList();
        }
        public Tournament TournamentRating(int id)
        {
            return _context.Tournaments.Include(t=>t.Ratings).Include(t => t.Teams).Include(t => t.Matches).Include(t => t.League).FirstOrDefault(t => t.Id == id);
        }
        public void AddRange(List<Rating> ratings)
        {
            _context.Ratings.AddRange(ratings);
        }
        public void Update(Rating rating)
        {
            if (rating.Id == 0)
            {
                _context.Ratings.Add(rating);
            }
            else
            {
                _context.Entry(rating).State = EntityState.Modified;
            }
        }
    }
}
