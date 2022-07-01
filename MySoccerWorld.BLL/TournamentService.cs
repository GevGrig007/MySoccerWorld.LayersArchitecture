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
    public class TournamentService : ITournamentService
    {
        public static readonly int PointsForWin = 3;
        public static readonly int PointsForDraw = 1;
        public static readonly int PointsForLoss = 0;
        public List<TournamentTable> CalculatingTable(IEnumerable<Match> matches, ICollection<Team> teams)
        {
            var table = new List<TournamentTable>();
            foreach (var team in teams)
            {
                var HomeGames = matches
                    .Where(fixture => fixture.HomeScore != null && fixture.Home.Id == team.Id)
                    .ToArray();
                var AwayGames = matches
                    .Where(fixture => fixture.AwayScore != null && fixture.Away.Id == team.Id)
                    .ToArray();
                var Games = HomeGames.Length + AwayGames.Length;
                var Win = HomeGames.Count(fixture => fixture.HomeScore > fixture.AwayScore) +
                    AwayGames.Count(fixture => fixture.AwayScore > fixture.HomeScore);
                var Draw = HomeGames.Count(fixture => fixture.HomeScore == fixture.AwayScore) +
                    AwayGames.Count(fixture => fixture.AwayScore == fixture.HomeScore);
                var Lost = HomeGames.Count(fixture => fixture.HomeScore < fixture.AwayScore) +
                    AwayGames.Count(fixture => fixture.AwayScore < fixture.HomeScore);
                var GoalsFor = HomeGames.Sum(fixture => fixture.HomeScore) +
                    AwayGames.Sum(fixture => fixture.AwayScore);
                var GoalsAgainst = HomeGames.Sum(fixture => fixture.AwayScore) +
                    AwayGames.Sum(fixture => fixture.HomeScore);
                var GoalDifference = GoalsFor - GoalsAgainst;
                var Points = (Win * PointsForWin) + (Draw * PointsForDraw) + (Lost * PointsForLoss);
                var tournamentTable = new TournamentTable
                {
                    TeamName = team.Name,
                    Team = team,
                    Played = Games,
                    Won = Win,
                    Draw = Draw,
                    Lost = Lost,
                    GoalsFor = GoalsFor,
                    GoalsAgainst = GoalsAgainst,
                    GoalDifference = GoalDifference,
                    Points = Points,
                    Flag = team.Flag
                };
                table.Add(tournamentTable);

            }
            return table;
        }
        public List<TournamentGroup> Group4(Tournament tournament)
        {
            var groupAm = tournament.Matches.Where(m => m.Group == "A");
            var team1 = groupAm.ToList()[0].Home;
            var team2 = groupAm.ToList()[0].Away;
            var team3 = groupAm.ToList()[5].Home;
            var team4 = groupAm.ToList()[5].Away;
            var groupAteams = new List<Team> { team1, team2, team3, team4 };
            var standingsA = CalculatingTable(groupAm, groupAteams);
            var groupA = new TournamentGroup()
            {
                Name = "A",
                Teams = groupAteams,
                Tournament = tournament,
                Matches = groupAm,
                GroupStandings = standingsA.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupBm = tournament.Matches.Where(m => m.Group == "B");
            var team5 = groupBm.ToList()[0].Home;
            var team6 = groupBm.ToList()[0].Away;
            var team7 = groupBm.ToList()[1].Home;
            var team8 = groupBm.ToList()[1].Away;
            var groupBteams = new List<Team> { team5, team6, team7, team8 };
            var standingsB = CalculatingTable(groupBm, groupBteams);
            var groupB = new TournamentGroup()
            {
                Name = "B",
                Teams = groupBteams,
                Tournament = tournament,
                Matches = groupBm,
                GroupStandings = standingsB.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupCm = tournament.Matches.Where(m => m.Group == "C");
            var team9 = groupCm.ToList()[0].Home;
            var team10 = groupCm.ToList()[0].Away;
            var team11 = groupCm.ToList()[1].Home;
            var team12 = groupCm.ToList()[1].Away;
            var groupCteams = new List<Team> { team9, team10, team11, team12 };
            var standingsC = CalculatingTable(groupCm, groupCteams);
            var groupC = new TournamentGroup()
            {
                Name = "C",
                Teams = groupCteams,
                Tournament = tournament,
                Matches = groupCm,
                GroupStandings = standingsC.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupDm = tournament.Matches.Where(m => m.Group == "D");
            var team13 = groupDm.ToList()[0].Home;
            var team14 = groupDm.ToList()[0].Away;
            var team15 = groupDm.ToList()[1].Home;
            var team16 = groupDm.ToList()[1].Away;
            var groupDteams = new List<Team> { team13, team14, team15, team16 };
            var standingsD = CalculatingTable(groupDm, groupDteams);
            var groupD = new TournamentGroup()
            {
                Name = "D",
                Teams = groupDteams,
                Tournament = tournament,
                Matches = groupDm,
                GroupStandings = standingsD.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groups = new List<TournamentGroup>() { groupA, groupB, groupC, groupD };
            return groups;
        }
        public List<TournamentGroup> Group8(Tournament tournament)
        {
            var groupAm = tournament.Matches.Where(m => m.Group == "A");
            var team1 = groupAm.ToList()[0].Home;
            var team2 = groupAm.ToList()[0].Away;
            var team3 = groupAm.ToList()[1].Home;
            var team4 = groupAm.ToList()[1].Away;
            var groupAteams = new List<Team> { team1, team2, team3, team4 };
            var standingsA = CalculatingTable(groupAm, groupAteams);
            var groupA = new TournamentGroup()
            {
                Name = "A",
                Teams = groupAteams,
                Tournament = tournament,
                Matches = groupAm,
                GroupStandings = standingsA.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupBm = tournament.Matches.Where(m => m.Group == "B");
            var team5 = groupBm.ToList()[0].Home;
            var team6 = groupBm.ToList()[0].Away;
            var team7 = groupBm.ToList()[1].Home;
            var team8 = groupBm.ToList()[1].Away;
            var groupBteams = new List<Team> { team5, team6, team7, team8 };
            var standingsB = CalculatingTable(groupBm, groupBteams);
            var groupB = new TournamentGroup()
            {
                Name = "B",
                Teams = groupBteams,
                Tournament = tournament,
                Matches = groupBm,
                GroupStandings = standingsB.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupCm = tournament.Matches.Where(m => m.Group == "C");
            var team9 = groupCm.ToList()[0].Home;
            var team10 = groupCm.ToList()[0].Away;
            var team11 = groupCm.ToList()[1].Home;
            var team12 = groupCm.ToList()[1].Away;
            var groupCteams = new List<Team> { team9, team10, team11, team12 };
            var standingsC = CalculatingTable(groupCm, groupCteams);
            var groupC = new TournamentGroup()
            {
                Name = "C",
                Teams = groupCteams,
                Tournament = tournament,
                Matches = groupCm,
                GroupStandings = standingsC.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupDm = tournament.Matches.Where(m => m.Group == "D");
            var team13 = groupDm.ToList()[0].Home;
            var team14 = groupDm.ToList()[0].Away;
            var team15 = groupDm.ToList()[1].Home;
            var team16 = groupDm.ToList()[1].Away;
            var groupDteams = new List<Team> { team13, team14, team15, team16 };
            var standingsD = CalculatingTable(groupDm, groupDteams);
            var groupD = new TournamentGroup()
            {
                Name = "D",
                Teams = groupDteams,
                Tournament = tournament,
                Matches = groupDm,
                GroupStandings = standingsD.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupEm = tournament.Matches.Where(m => m.Group == "E");
            var team17 = groupEm.ToList()[0].Home;
            var team18 = groupEm.ToList()[0].Away;
            var team19 = groupEm.ToList()[1].Home;
            var team20 = groupEm.ToList()[1].Away;
            var groupEteams = new List<Team> { team17, team18, team19, team20 };
            var standingsE = CalculatingTable(groupEm, groupEteams);
            var groupE = new TournamentGroup()
            {
                Name = "E",
                Teams = groupEteams,
                Tournament = tournament,
                Matches = groupEm,
                GroupStandings = standingsE.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupFm = tournament.Matches.Where(m => m.Group == "F");
            var team21 = groupFm.ToList()[0].Home;
            var team22 = groupFm.ToList()[0].Away;
            var team23 = groupFm.ToList()[1].Home;
            var team24 = groupFm.ToList()[1].Away;
            var groupFteams = new List<Team> { team21, team22, team23, team24 };
            var standingsF = CalculatingTable(groupFm, groupFteams);
            var groupF = new TournamentGroup()
            {
                Name = "F",
                Teams = groupFteams,
                Tournament = tournament,
                Matches = groupFm,
                GroupStandings = standingsF.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupGm = tournament.Matches.Where(m => m.Group == "G");
            var team25 = groupGm.ToList()[0].Home;
            var team26 = groupGm.ToList()[0].Away;
            var team27 = groupGm.ToList()[1].Home;
            var team28 = groupGm.ToList()[1].Away;
            var groupGteams = new List<Team> { team25, team26, team27, team28 };
            var standingsG = CalculatingTable(groupGm, groupGteams);
            var groupG = new TournamentGroup()
            {
                Name = "G",
                Teams = groupGteams,
                Tournament = tournament,
                Matches = groupGm,
                GroupStandings = standingsG.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupHm = tournament.Matches.Where(m => m.Group == "H");
            var team29 = groupHm.ToList()[0].Home;
            var team30 = groupHm.ToList()[0].Away;
            var team31 = groupHm.ToList()[1].Home;
            var team32 = groupHm.ToList()[1].Away;
            var groupHteams = new List<Team> { team29, team30, team31, team32 };
            var standingsH = CalculatingTable(groupHm, groupHteams);
            var groupH = new TournamentGroup()
            {
                Name = "H",
                Teams = groupHteams,
                Tournament = tournament,
                Matches = groupHm,
                GroupStandings = standingsH.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groups = new List<TournamentGroup>() { groupA, groupB, groupC, groupD, groupE, groupF, groupG, groupH };
            return groups;
        }
                
        public List<TournamentGroup> EuroGroup(Tournament tournament)
        {
            var groupAm = tournament.Matches.Where(m => m.Group == "A").OrderBy(m => m.Round);
            var team1 = groupAm.ToList()[0].Home;
            var team2 = groupAm.ToList()[0].Away;
            var team3 = groupAm.ToList()[1].Home;
            var team4 = groupAm.ToList()[1].Away;
            var team5 = groupAm.ToList()[2].Home;
            var groupAteams = new List<Team> { team1, team2, team3, team4, team5 };
            var standingsA = CalculatingTable(groupAm, groupAteams);
            var groupA = new TournamentGroup()
            {
                Name = "A",
                Teams = groupAteams,
                Tournament = tournament,
                Matches = groupAm,
                GroupStandings = standingsA.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupBm = tournament.Matches.Where(m => m.Group == "B").OrderBy(m => m.Round);
            var team6 = groupBm.ToList()[0].Home;
            var team7 = groupBm.ToList()[0].Away;
            var team8 = groupBm.ToList()[1].Home;
            var team9 = groupBm.ToList()[1].Away;
            var team10 = groupBm.ToList()[2].Home;
            var groupBteams = new List<Team> { team6, team7, team8, team9, team10 };
            var standingsB = CalculatingTable(groupBm, groupBteams);
            var groupB = new TournamentGroup()
            {
                Name = "B",
                Teams = groupBteams,
                Tournament = tournament,
                Matches = groupBm,
                GroupStandings = standingsB.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupCm = tournament.Matches.Where(m => m.Group == "C").OrderBy(m => m.Round);
            var team11 = groupCm.ToList()[0].Home;
            var team12 = groupCm.ToList()[0].Away;
            var team13 = groupCm.ToList()[1].Home;
            var team14 = groupCm.ToList()[1].Away;
            var team15 = groupCm.ToList()[2].Home;
            var groupCteams = new List<Team> { team11, team12, team13, team14, team15 };
            var standingsC = CalculatingTable(groupCm, groupCteams);
            var groupC = new TournamentGroup()
            {
                Name = "C",
                Teams = groupCteams,
                Tournament = tournament,
                Matches = groupCm,
                GroupStandings = standingsC.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupDm = tournament.Matches.Where(m => m.Group == "D").OrderBy(m => m.Round);
            var team16 = groupDm.ToList()[0].Home;
            var team17 = groupDm.ToList()[0].Away;
            var team18 = groupDm.ToList()[1].Home;
            var team19 = groupDm.ToList()[1].Away;
            var team20 = groupDm.ToList()[2].Home;
            var groupDteams = new List<Team> { team16, team17, team18, team19, team20 };
            var standingsD = CalculatingTable(groupDm, groupDteams);
            var groupD = new TournamentGroup()
            {
                Name = "D",
                Teams = groupDteams,
                Tournament = tournament,
                Matches = groupDm,
                GroupStandings = standingsD.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groups = new List<TournamentGroup>() { groupA, groupB, groupC, groupD };
            return groups;
        }

        public List<TournamentGroup> Group2(Tournament tournament)
        {
            var groupAm = tournament.Matches.Where(m => m.Group == "A");
            var team1 = groupAm.ToList()[0].Home;
            var team2 = groupAm.ToList()[0].Away;
            var team3 = groupAm.ToList()[1].Home;
            var team4 = groupAm.ToList()[1].Away;
            var groupAteams = new List<Team> { team1, team2, team3, team4 };
            var standingsA = CalculatingTable(groupAm, groupAteams);
            var groupA = new TournamentGroup()
            {
                Name = "A",
                Teams = groupAteams,
                Tournament = tournament,
                Matches = groupAm,
                GroupStandings = standingsA.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groupBm = tournament.Matches.Where(m => m.Group == "B");
            var team5 = groupBm.ToList()[0].Home;
            var team6 = groupBm.ToList()[0].Away;
            var team7 = groupBm.ToList()[1].Home;
            var team8 = groupBm.ToList()[1].Away;
            var groupBteams = new List<Team> { team5, team6, team7, team8 };
            var standingsB = CalculatingTable(groupBm, groupBteams);
            var groupB = new TournamentGroup()
            {
                Name = "B",
                Teams = groupBteams,
                Tournament = tournament,
                Matches = groupBm,
                GroupStandings = standingsB.OrderByDescending(c => c.Points)
                                           .ThenByDescending(c => c.GoalDifference)
                                           .ThenByDescending(c => c.GoalsFor)
            };
            var groups = new List<TournamentGroup>() { groupA, groupB };
            return groups;
        }
    }
}
