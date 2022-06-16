using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class QualificationViewModel
    {
        public Tournament Tournament { get; set; }
        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
    }
}
