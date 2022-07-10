using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team Get(int id);
        Team Details(int id);
        void Update(Team match);
        void Delete(int id);
    }
}
