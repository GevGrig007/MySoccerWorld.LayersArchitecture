using MySoccerWorld.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class TournamentAward
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public AwardType AwardName { get; set; }
        public int? PlayerTeamId { get; set; }
        public virtual PlayerTeam PlayerTeam { get; set; }
        public int? CoachTeamId { get; set; }
        public virtual CoachTeam CoachTeam { get; set; }
    }
}
