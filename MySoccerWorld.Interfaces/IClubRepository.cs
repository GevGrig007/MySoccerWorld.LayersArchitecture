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
        Task<Team> Get(int id);
        Task<Club> Details(int id);
        IEnumerable<Club> GetAll();
        IQueryable<Club> ClubSort();
        Task<List<Club>> Rating();
        Task<List<Player>> Players(int id);
        IEnumerable<Country> Countries();     
        Task Update(Club club);
        Task Delete(int id);
    }
}
