using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface ICoachRepository
    {
        IEnumerable<Coach> GetAll();
        CoachTeam Get(int? id);
    }
}
