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
        IEnumerable<Coach> GetByTournament(int id);
        Coach Get(int? id);
        Coach Details(int id);
        IQueryable<Coach> Sort();
        void UpdateCoachTeams(CoachTeam coachTeam);
        void Update(Coach coach);
        void Delete(int id);
    }
}
