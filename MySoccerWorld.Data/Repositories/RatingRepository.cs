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
        public Rating Get(int id) => _context.Ratings.Find(id);
        public Tournament TournamentRating(int id) =>
                          _context.Tournaments.Include(t => t.Ratings).Include(t => t.Teams).Include(t => t.Matches)
                                              .Include(t => t.League).FirstOrDefault(t => t.Id == id);
        public IEnumerable<Rating> GetAll() => _context.Ratings;
        public IEnumerable<Player> TopScorers() =>
                          _context.Players.Include(p => p.Country).Include(p => p.PlayerTeams).ThenInclude(p => p.Goals)
                                          .Include(p => p.PlayerTeams).ThenInclude(p => p.Asists).ToList();
        public IEnumerable<Player> SeasonalScorers(int id) =>
                          _context.Players.Include(p => p.Country).Include(p => p.PlayerTeams)
                                          .ThenInclude(p => p.Goals.Where(g => g.Match.Tournament.SeasonId == id)).Include(p => p.PlayerTeams)
                                          .ThenInclude(p => p.Asists.Where(g => g.Match.Tournament.SeasonId == id)).ToList();
        public IEnumerable<Club> ClubMedals() =>
                _context.Clubs.Include(c => c.Ratings.Where(r => r.Position == 1 || r.Position == 2 && r.Position == 3
                              || r.Round == "Winner" || r.Round == "Silver" || r.Round == "Bronze"))
                              .OrderByDescending(r => r.Ratings.Count(r => r.Position == 1 || r.Position == 2 || r.Position == 3
                              || r.Round == "Winner" || r.Round == "Silver" || r.Round == "Bronze")).Include(c => c.Country).ToList();
        public IEnumerable<National> NationalMedals() =>
                _context.Nationals.Include(c => c.Ratings.Where(r => r.Position == 1 || r.Position == 2 && r.Position == 3
                                  || r.Round == "Winner" || r.Round == "Silver" || r.Round == "Bronze"))
                                  .OrderByDescending(r => r.Ratings.Count(r => r.Position == 1 || r.Position == 2 || r.Position == 3
                                  || r.Round == "Winner" || r.Round == "Silver" || r.Round == "Bronze")).ToList();
        public IEnumerable<Country> CountriesMedal()
        {
            var countries = _context.Countries.Where(c => c.Region != null);
            return countries.Include(c => c.Clubs).ThenInclude(c => c.Ratings.Where(r => r.Position == 1 || r.Position == 2 && r.Position == 3
                            || r.Round == "Winner" || r.Round == "Silver" || r.Round == "Bronze")).ToList()
                            .OrderByDescending(c => c.Clubs.Sum(r => r.Ratings.Count())).ToList();
        }
        public void AddRange(List<Rating> ratings) => _context.Ratings.AddRange(ratings);
        public void Update(Rating rating)
        {
            if (rating.Id == 0) _context.Ratings.Add(rating);
            else _context.Entry(rating).State = EntityState.Modified;
        }
    }
}
