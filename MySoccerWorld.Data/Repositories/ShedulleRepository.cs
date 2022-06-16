using MySoccerWorld.EF.Data;
using MySoccerWorld.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Data.Repositories
{
    public class ShedulleRepository : IShedulleRepository
    {
        private SoccerContext _context;
        public ShedulleRepository(SoccerContext context)
        {
            _context = context;
        }
    }
}
