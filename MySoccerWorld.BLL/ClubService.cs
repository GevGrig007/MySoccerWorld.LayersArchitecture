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
    public class ClubService : IClubService
    {
        public ClubStats Stats(Team team,List<Match> matches)
        {
            List<Match> Homes = matches.Where(m => m.HomeTeam == team.Id).ToList();
            List<Match> Aways = matches.Where(m => m.AwayTeam == team.Id).ToList();
            var stats = new ClubStats
            {
                Games = matches.Count,
                Win = Homes.Count(m => m.HomeScore > m.AwayScore) + Aways.Count(m => m.AwayScore > m.HomeScore),
                Draw = matches.Count(m => m.HomeScore == m.AwayScore),
                Lost = Homes.Count(m => m.HomeScore < m.AwayScore) + Aways.Count(m => m.AwayScore < m.HomeScore),
                GoalsFor = Homes.Sum(m => m.HomeScore) + Homes.Sum(m => m.HomeEx) + Aways.Sum(m => m.AwayEx) + Aways.Sum(m => m.AwayScore),
                GoalsAgainst = Homes.Sum(m => m.AwayScore) + Homes.Sum(m => m.AwayEx) + Aways.Sum(m => m.HomeEx) + Aways.Sum(m => m.HomeScore),
                OverResultGame = matches.OrderBy(m => m.HomeScore + m.AwayScore).Last(),
                MaxWin = Homes.OrderByDescending(m => (m.HomeScore - m.AwayScore) - (m.AwayScore - m.HomeScore)).First(),
            };
            return stats;
        }

    }
}
