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
        IEnumerable<National> Rating();
        National Details(int id);
        National Get(int id);
        void Update(National national);
    }
}
