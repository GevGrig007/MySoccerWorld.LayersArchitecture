using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        void Update(Player player);
        void Delete(int id);
        Player Get(int id);
        Player Details(int id);
        List<Player> ClubPlayers(int id);
        List<Player> NationalPlayers(int id);
        IQueryable<Player> Sort();
    }
}
