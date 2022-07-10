using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> GetAll();
        IEnumerable<Tournament> GetByLeague(int id);
        Task<Tournament> GetAsync(int id);
        Task<Tournament> DetailsAsync(int id);
        Task UpdateAsync(Tournament tournament);
        Task DeleteAsync(int id);
    }
}
