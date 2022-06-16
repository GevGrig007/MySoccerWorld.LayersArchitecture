using MySoccerWorld.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Tournament
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Division { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Place { get; set; }
        public TournamentType? TournamentType { get; set; }
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual List<BestPlayer> BestPlayers { get; set; }
        public BestPlayerFormation? BestPlayerFormation { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<TournamentAward> TournamentAwards { get; set; }

        public Tournament()
        {
            BestPlayers = new List<BestPlayer>();
        }
    }
}
