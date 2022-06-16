using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class BestPlayer
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int Position { get; set; }
        public int PlayerTeamId { get; set; }
        public virtual PlayerTeam PlayerTeam { get; set; }
    }
}
