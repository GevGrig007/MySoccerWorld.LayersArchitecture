using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Model
{
    public class LeagueStats
    {
        public int Games { get; set; }
        public int? Goals { get; set; }
        public Match OverResultGame { get; set; }
        public Match MaxWin { get; set; }
        public double? AverageTotal { get; set; }
    }
}
