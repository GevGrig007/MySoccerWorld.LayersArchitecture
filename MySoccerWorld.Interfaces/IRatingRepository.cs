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
        Rating Get(int id);
        Tournament TournamentRating(int id);
        IEnumerable<Rating> GetAll();
        IEnumerable<Player> TopScorers();
        IEnumerable<Player> SeasonalScorers(int id);  
        IEnumerable<Club> ClubMedals();
        IEnumerable<National> NationalMedals();
        IEnumerable<Country> CountriesMedal();
        void AddRange(List<Rating> ratings);
        void Update(Rating rating); 
    }
}
