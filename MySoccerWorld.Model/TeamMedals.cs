using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model
{
    public class TeamMedals
    {
        public Team Team { get; set; }
        public string MedalName { get; set; }
        public Tournament Tournament { get; set; }
    }
}
