using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public string Round { get; set; }
        public string Group { get; set; }
        public bool Neytral { get; set; }
        public double? Data { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public byte? HomeScore { get; set; }
        public byte? AwayScore { get; set; }
        public byte? HomeEx { get; set; }
        public byte? AwayEx { get; set; }
        public byte? HomePen { get; set; }
        public byte? AwayPen { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Asist> Asists { get; set; }
    }
}
