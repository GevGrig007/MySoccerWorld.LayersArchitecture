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
        void Update(Tournament tournament);
        void Delete(int id);
        Tournament Get(int id);
        Tournament Details(int id);
    }
}
