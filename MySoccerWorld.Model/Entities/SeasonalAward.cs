using MySoccerWorld.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class SeasonalAward
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public int? PlayerTeamId { get; set; }
        public virtual PlayerTeam PlayerTeam { get; set; }
        public SeasonalAwardType AwardName { get; set; }
        public int? CoachTeamId { get; set; }
        public virtual CoachTeam CoachTeam { get; set; }
    }
}
