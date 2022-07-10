using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IClubRepository
    {        
        Task<Team> GetAsync(int id);
        Task<Club> DetailsAsync(int id);
        IEnumerable<Club> GetAll();
        IQueryable<Club> ClubSort();
        Task<List<Club>> RatingAsync();
        List<Player> Players(int id);
        IEnumerable<Country> Countries();     
        Task UpdateAsync(Club club);
        Task DeleteAsync(int id);
    }
}
