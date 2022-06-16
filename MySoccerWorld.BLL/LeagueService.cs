using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.BLL
{
    public class LeagueService : ILeagueService
    {
        public LeagueStats Stats(List<Match> matches)
        {
            var stats = new LeagueStats()
            {
                Games = matches.Count,
                Goals = matches.Sum(m => m.HomeScore + m.AwayScore),
                OverResultGame = matches.OrderBy(m => m.HomeScore + m.AwayScore).Last(),
                AverageTotal = matches.Average(m => m.HomeScore + m.AwayScore),
                MaxWin = matches.OrderByDescending(m => (m.HomeScore - m.AwayScore) - (m.AwayScore - m.HomeScore)).First()
            };
            return stats;
        }
    }
}
