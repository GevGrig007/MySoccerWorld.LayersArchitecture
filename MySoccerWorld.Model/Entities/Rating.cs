using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public double? Points { get; set; }
        public int? Position { get; set; }
        public string Round { get; set; }
    }
}
