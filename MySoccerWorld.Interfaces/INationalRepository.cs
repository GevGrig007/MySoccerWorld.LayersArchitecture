using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface INationalRepository
    {
        IQueryable<National> GetAll();
        National Details(int id);
        National Get(int id);
        IEnumerable<National> Rating();
        void Update(National national);
    }
}
