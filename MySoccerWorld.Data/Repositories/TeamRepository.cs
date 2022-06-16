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
    public class TeamRepository : ITeamRepository
    {
        private readonly SoccerContext _context;
        public TeamRepository(SoccerContext db)
        {
            _context = db;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Team Details(int id)
        {
           return _context.Teams.Include(t => t.PlayerTeams).ThenInclude(t => t.Player).FirstOrDefault(t=>t.Id==id);
        }
        public Team Get(int id)
        {
            return _context.Teams.Find(id);
        }
        public IEnumerable<Team> GetAll()
        {
            return _context.Teams;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Team team)
        {
            if (team.Id == 0)
            {
                _context.Teams.Add(team);
            }
            else
            {
                _context.Entry(team).State = EntityState.Modified;
            }
        }
    }
}
