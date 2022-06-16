using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface ISeasonRepository
    {
        Season Get(int? id);
        void Update(Season season);
        void Save();
        IEnumerable<Season> GetAll();
    }
}
