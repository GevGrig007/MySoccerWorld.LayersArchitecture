using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class PlayerTeam
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int? SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Asist> Asists { get; set; }
        public virtual ICollection<BestPlayer> BestPlayers { get; set; }
        public virtual ICollection<TournamentAward> TournamentAwards { get; set; }
        public virtual ICollection<SeasonalAward> SeasonalAwards { get; set; }
        public PlayerTeam()
        {
            Goals = new List<Goal>();

            Asists = new List<Asist>();
        }
    }
}
