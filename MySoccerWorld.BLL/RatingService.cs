using MySoccerWorld.Model.Entities;
using MySoccerWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.BLL
{
    public class RatingService : IRatingService
    {
        public static readonly int PointsForHomeWin = 3;
        public static readonly int PointsForHomeDraw = 1;
        public static readonly int PointsForAwayWin = 4;
        public static readonly int PointsForAwayDraw = 1;
        public static readonly double PointsForGoals = 0.25;
        public static readonly double PointsForBigWin = 0.25;
        public List<Rating> TeamRatingsRegular(Tournament tournament)
        {
            var ratings = new List<Rating>();
            var teams = tournament.Teams.ToList();
            var matches = tournament.Matches.ToList();
            var tournamentTable = new TournamentService();
            var tournamentPosition = tournamentTable.CalculatingTable(tournament.Matches, tournament.Teams);
            var standings = tournamentPosition.OrderByDescending(c => c.Points)
                                                         .ThenByDescending(c => c.GoalDifference)
                                                         .ThenByDescending(c => c.GoalsFor);
            var position = standings.Select((p, i) => new { Index = i + 1, standing = p });
            foreach (var team in teams)
            {
                var AllPoints = new List<double?>();
                var HomeGames = matches.Where(fixture => fixture.HomeScore != null && fixture.Home.Id == team.Id).ToArray();
                var AwayGames = matches.Where(fixture => fixture.AwayScore != null && fixture.Away.Id == team.Id).ToArray();
                var HomeWin = HomeGames.Count(fixture => fixture.HomeScore > fixture.AwayScore);
                var AwayWin = AwayGames.Count(fixture => fixture.HomeScore < fixture.AwayScore);
                var HomeDraw = HomeGames.Count(fixture => fixture.HomeScore == fixture.AwayScore);
                var AwayDraw = AwayGames.Count(fixture => fixture.HomeScore == fixture.AwayScore);
                var Goals = HomeGames.Sum(fixture => fixture.HomeScore) + AwayGames.Sum(fixture => fixture.AwayScore);
                var BigWin = HomeGames.Count(m => ((m.HomeScore - m.AwayScore) > 2)) + AwayGames.Count(m => ((m.AwayScore - m.HomeScore) > 2));
                var PointsForMatches = (HomeWin * PointsForHomeWin) + (AwayWin * PointsForAwayWin) + (HomeDraw * PointsForHomeDraw)
                             + (AwayDraw * PointsForAwayDraw) + (Goals * PointsForGoals) + (BigWin * PointsForBigWin);
                AllPoints.Add(PointsForMatches);
                var Position = position.Where(p => p.standing.Team == team).Single();
                var teamPosition = Position.Index;
                if (tournament.Teams.Count == 16)
                {
                    int PointsForPosition;
                    if (teamPosition == 1) PointsForPosition = 10;
                    else if (teamPosition == 2) PointsForPosition = 8;
                    else if (teamPosition == 3) PointsForPosition = 7;
                    else if (teamPosition == 4) PointsForPosition = 6;
                    else if (teamPosition == 5) PointsForPosition = 5;
                    else if (teamPosition == 6) PointsForPosition = 4;
                    else if (teamPosition == 7) PointsForPosition = 4;
                    else if (teamPosition == 8) PointsForPosition = 3;
                    else if (teamPosition == 9) PointsForPosition = 3;
                    else if (teamPosition == 10) PointsForPosition = 2;
                    else if (teamPosition == 11) PointsForPosition = 2;
                    else if (teamPosition == 12) PointsForPosition = 1;
                    else if (teamPosition == 13) PointsForPosition = 1;
                    else if (teamPosition == 14) PointsForPosition = 1;
                    else if (teamPosition == 15) PointsForPosition = 0;
                    else PointsForPosition = 0;
                    AllPoints.Add(PointsForPosition);
                }
                else if (tournament.Teams.Count == 9)
                {
                    int PointsForPosition;
                    if (teamPosition == 1) PointsForPosition = 10;
                    else if (teamPosition == 2) PointsForPosition = 8;
                    else if (teamPosition == 3) PointsForPosition = 6;
                    else if (teamPosition == 4) PointsForPosition = 5;
                    else if (teamPosition == 5) PointsForPosition = 4;
                    else if (teamPosition == 6) PointsForPosition = 3;
                    else if (teamPosition == 7) PointsForPosition = 2;
                    else if (teamPosition == 8) PointsForPosition = 1;
                    else if (teamPosition == 9) PointsForPosition = 0;
                    else PointsForPosition = 0;
                    AllPoints.Add(PointsForPosition);
                }
                else
                {
                    int PointsForPosition;
                    if (teamPosition == 1) PointsForPosition = 10;
                    else if (teamPosition == 2) PointsForPosition = 8;
                    else if (teamPosition == 3) PointsForPosition = 6;
                    else if (teamPosition == 4) PointsForPosition = 5;
                    else if (teamPosition == 5) PointsForPosition = 4;
                    else if (teamPosition == 6) PointsForPosition = 3;
                    else if (teamPosition == 7) PointsForPosition = 3;
                    else if (teamPosition == 8) PointsForPosition = 2;
                    else if (teamPosition == 9) PointsForPosition = 2;
                    else if (teamPosition == 10) PointsForPosition = 1;
                    else if (teamPosition == 11) PointsForPosition = 1;
                    else PointsForPosition = 0;
                    AllPoints.Add(PointsForPosition);
                }
                var teamPoints = (Double)AllPoints.Sum();
                if (tournament.Division == "2") { teamPoints = teamPoints * 0.25; }
                if (tournament.Division == "3") { teamPoints = teamPoints * 0.15; }
                var roundPoints = Math.Round(teamPoints, 1);
                var rating = new Rating
                {
                    Team = team,
                    TournamentId = tournament.Id,
                    Points = roundPoints,
                    Position = teamPosition
                };
                ratings.Add(rating);
            }
            return ratings;
        }
        public List<Rating> TeamRatingEuroCup(Tournament tournament)
        {
            var ratings = new List<Rating>();
            var teams = tournament.Teams.ToList();
            var matches = tournament.Matches.ToList();
            foreach (var team in teams)
            {
                var AllPoints = new List<double?>();
                var HomeGames = new List<Match>();
                if (matches.Where(m => m.HomeScore != null && m.HomeTeam == team.Id) != null)
                {
                    HomeGames.AddRange(matches.Where(m => m.HomeScore != null && m.HomeTeam == team.Id));
                }
                var AwayGames = matches.Where(m => m.AwayScore != null && m.AwayTeam == team.Id).ToArray();
                var Win = HomeGames.Count(m => m.HomeScore > m.AwayScore) + AwayGames.Count(m => m.HomeScore < m.AwayScore);
                var Draw = HomeGames.Count(m => m.HomeScore == m.AwayScore) + AwayGames.Count(m => m.HomeScore == m.AwayScore);
                var ExWin = HomeGames.Count(m => m.HomeEx > m.AwayEx) + AwayGames.Count(m => m.HomeEx < m.AwayEx);
                var ExDraw = HomeGames.Count(m => m.HomeEx == m.AwayEx) + AwayGames.Count(m => m.HomeEx == m.AwayEx);
                var Goals = HomeGames.Sum(m => m.HomeScore) + HomeGames.Sum(m => m.HomeEx) + AwayGames.Sum(m => m.AwayEx) + AwayGames.Sum(m => m.AwayScore);
                var BigWin = HomeGames.Count(m => ((m.HomeScore - m.AwayScore) > 2)) + AwayGames.Count(m => ((m.AwayScore - m.HomeScore) > 2));
                var PointsForMatches = (Win * 4) + (ExWin * 2) + (ExDraw * 1) + (Draw * 1) + (Goals * 0.25) + (BigWin * 0.25);
                AllPoints.Add(PointsForMatches);
                if (HomeGames.Any(m => m.Round == "1/32 finals") || AwayGames.Any(m => m.Round == "1/32 finals")) { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "1/16 finals") || AwayGames.Any(m => m.Round == "1/16 finals")) { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "1/8 finals") || AwayGames.Any(m => m.Round == "1/8 finals")) { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "1/4 finals") || AwayGames.Any(m => m.Round == "1/4 finals")) { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "1/2 finals") || AwayGames.Any(m => m.Round == "1/2 finals")) { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "Bronze-Match" && (m.HomeScore > m.AwayScore || m.HomeEx > m.AwayEx || m.HomePen > m.AwayPen)))
                { AllPoints.Add(1); }
                if (AwayGames.Any(m => m.Round == "Bronze-Match" && (m.HomeScore < m.AwayScore || m.HomeEx < m.AwayEx || m.HomePen < m.AwayPen)))
                { AllPoints.Add(1); }
                if (HomeGames.Any(m => m.Round == "Final" && (m.HomeScore > m.AwayScore || m.HomeEx > m.AwayEx || m.HomePen > m.AwayPen)))
                { AllPoints.Add(1); }
                if (AwayGames.Any(m => m.Round == "Final" && (m.HomeScore < m.AwayScore || m.HomeEx < m.AwayEx || m.HomePen < m.AwayPen)))
                { AllPoints.Add(1); }
                string round = "";
                if (HomeGames.Any(m=>m.Round=="Final") && AwayGames.Any(m=>m.Round=="Final"))
                {
                    var firstFinalMatch = HomeGames.Where(m => m.Round == "Final" && m.HomeTeam == team.Id).FirstOrDefault();
                    var secondFinalMatch = AwayGames.Where(m => m.Round == "Final" && m.AwayTeam == team.Id).FirstOrDefault();
                    if (firstFinalMatch.HomeScore + secondFinalMatch.AwayScore >
                       firstFinalMatch.AwayScore + secondFinalMatch.HomeScore
                       || firstFinalMatch.HomeEx > firstFinalMatch.AwayEx || secondFinalMatch.HomeEx < secondFinalMatch.AwayEx
                       || firstFinalMatch.HomePen > firstFinalMatch.AwayPen || firstFinalMatch.HomePen < firstFinalMatch.AwayPen)
                    {
                        round = "Winner";
                    }
                    else { round = "Silver"; }
                }
                else if (HomeGames.Any(m => m.Round == "Final") || AwayGames.Any(m => m.Round == "Final"))
                {
                    if (HomeGames.Any(m => m.Round == "Final" && (m.HomeScore > m.AwayScore || m.HomeEx > m.AwayEx || m.HomePen > m.AwayPen))
                        || AwayGames.Any(m => m.Round == "Final" && (m.HomeScore < m.AwayScore || m.HomeEx < m.AwayEx || m.HomePen < m.AwayPen)))
                       { round = "Winner"; }
                    else { round = "Silver"; }
                }
                else if (HomeGames.Any(m => m.Round == "Bronze-Match") && AwayGames.Any(m => m.Round == "Bronze-Match"))
                {
                    var firstFinalMatch = HomeGames.Where(m => m.Round == "Bronze-Match" && m.HomeTeam == team.Id).FirstOrDefault();
                    var secondFinalMatch = AwayGames.Where(m => m.Round == "Bronze-Match" && m.AwayTeam == team.Id).FirstOrDefault();
                    if (firstFinalMatch.HomeScore + secondFinalMatch.AwayScore >
                       firstFinalMatch.AwayScore + secondFinalMatch.HomeScore
                       || firstFinalMatch.HomeEx > firstFinalMatch.AwayEx || secondFinalMatch.HomeEx < secondFinalMatch.AwayEx
                       || firstFinalMatch.HomePen > firstFinalMatch.AwayPen || firstFinalMatch.HomePen < firstFinalMatch.AwayPen)
                    {
                        round = "Bronze";
                    }
                    else { round = "4th"; }
                }
                else if (HomeGames.Any(m => m.Round == "Bronze-Match") || AwayGames.Any(m => m.Round == "Bronze-Match"))
                {
                    if (HomeGames.Any(m => m.Round == "Bronze-Match" && (m.HomeScore > m.AwayScore || m.HomeEx > m.AwayEx || m.HomePen > m.AwayPen))
                         || AwayGames.Any(m => m.Round == "Bronze-Match" && (m.HomeScore < m.AwayScore || m.HomeEx < m.AwayEx || m.HomePen < m.AwayPen)))
                    { round = "Bronze"; }
                    else { round = "4th"; }
                }
                else if (HomeGames.Any(m => m.Round.Contains("1/4")) || AwayGames.Any(m => m.Round == "1/4")) { round = "1/4"; }
                else if (HomeGames.Any(m => m.Round.Contains("1/8")) || AwayGames.Any(m => m.Round == "1/8")) { round = "1/8"; }
                else if (HomeGames.Any(m => m.Round.Contains("1/16")) || AwayGames.Any(m => m.Round == "1/16")) { round = "1/16"; }
                else if (HomeGames.Any(m => m.Round.Contains("1/32")) || AwayGames.Any(m => m.Round == "1/32")) { round = "1/32"; }
                else if (HomeGames.Any(m => m.Round.Contains("1/64")) || AwayGames.Any(m => m.Round == "1/64")) { round = "1/64"; }
                else if (HomeGames.Any(m => m.Round.Contains("Q", StringComparison.OrdinalIgnoreCase)) || AwayGames.Any(m => m.Round.Contains("Q", StringComparison.OrdinalIgnoreCase))) { round = "Q"; }
                else { round = "GS"; }
                var teamPoints = AllPoints.Sum();
                if (tournament.League.Name == "League Champions") { teamPoints = teamPoints * 1.25; }
                if (tournament.League.Name == "EuroLeague") { teamPoints = teamPoints * 1; }
                if (tournament.League.Name == "Conferentions Cup") { teamPoints = teamPoints * 0.8; }
                if (tournament.League.Name == "Cup of Cups") { teamPoints = teamPoints * 0.5; }
                if (tournament.League.Name == "SuperCup PES") { teamPoints = teamPoints * 0.5; }
                if (tournament.League.Name == "UEFA EURO CUP") { teamPoints = teamPoints * 0.8; }
                var roundPoints = Math.Round((Double)teamPoints, 1);
                var rating = new Rating
                {
                    Team = team,
                    TournamentId = tournament.Id,
                    Points = roundPoints,
                    Round = round
                };
                ratings.Add(rating);
            }
            return ratings;
        }
    }
}
