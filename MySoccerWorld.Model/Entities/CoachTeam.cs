using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class CoachTeam
    {
        public int Id { get; set; }
        public int CoachId { get; set; }
        public virtual Coach Coach { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int? SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<TournamentAward> TournamentAwards { get; set; }
        public virtual ICollection<SeasonalAward> SeasonalAwards { get; set; }
    }
}
