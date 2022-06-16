using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Interfaces
{
    public interface IBestPlayerRepository
    {
        Task<BestPlayer> GetAsync(int id);
        IEnumerable<Player> GetPlayers();
        Task<List<BestPlayer>> GetByTournamentAsync(int id);
        Player GetClubsPlayer(int id);
        Task Update(BestPlayer bestPlayer);
    }
}
