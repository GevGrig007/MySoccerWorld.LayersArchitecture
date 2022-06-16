using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Text must be less than 50 characters")]
        public string Name { get; set; }
        public string Flag { get; set; }
        public virtual ICollection<Match> Homes { get; set; }
        public virtual ICollection<Match> Aways { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
        public ICollection<CoachTeam> CoachTeams { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public double? AllPoints
        {
            get
            {
                if (this.Ratings != null)
                {
                    var rating = Ratings.Sum(c => c.Points);
                    return rating;
                }
                else { return 0; }
            }
        }
    }
}
