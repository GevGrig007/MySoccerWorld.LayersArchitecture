using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAll();
        Tournament TournamentRating(int id);
        IEnumerable<Player> TopScorers();
        IEnumerable<Player> SeasonalScorers(int id);
        void Update(Rating rating);
        void AddRange(List<Rating> ratings);
        void Delete(int id);
        Rating Get(int id);
        Rating Details(int id);
    }
}
