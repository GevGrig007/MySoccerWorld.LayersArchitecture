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
    public class SeasonRepository : ISeasonRepository
    {
        private readonly SoccerContext _context;
        public SeasonRepository(SoccerContext db)
        {
            _context = db;
        }
        public Season Get(int? id)
        {
            return _context.Seasons.Find(id);
        }
        public void Update(Season season)
        {
            if (season.Id == 0)
            {
                _context.Seasons.Add(season);
            }
            else
            {
                _context.Entry(season).State = EntityState.Modified;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Season> GetAll()
        {
            return _context.Seasons;
        }
    }
}
