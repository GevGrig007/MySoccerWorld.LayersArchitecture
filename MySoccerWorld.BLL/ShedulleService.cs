using MySoccerWorld.Model.Entities;
using MySoccerWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.BLL
{
    public class ShedulleService : IShedulleService
    {
        public ICollection<Match> Final(Tournament turnir, List<Team> klubi, double startData)
        {
            var d = Math.Round(startData + 0.11, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "Bronze-Match", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = false, Data = d },
                new Match() { Round = "Final", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = false, Data = d }
            };
            return games;
        }
        public ICollection<Match> GenerateFor12Teams(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.01, 2);
            var d2 = Math.Round(startData + 0.02, 2);
            var d3 = Math.Round(startData + 0.03, 2);
            var d4 = Math.Round(startData + 0.04, 2);
            var d5 = Math.Round(startData + 0.05, 2);
            var d6 = Math.Round(startData + 0.06, 2);
            var d7 = Math.Round(startData + 0.07, 2);
            var d8 = Math.Round(startData + 0.08, 2);
            var games = new List<Match>()
            {
                new Match(){Round="1",Home=klubi[0],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[1],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[10],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[8],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[4],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[6],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="2",Home=klubi[2],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[3],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[5],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[7],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[11],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[9],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="3",Home=klubi[0],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[1],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[8],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[4],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[6],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[10],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="4",Home=klubi[7],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[5],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[2],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[3],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[9],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[11],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="5",Home=klubi[0],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[2],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[10],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[9],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[4],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[7],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="6",Home=klubi[6],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[5],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[3],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[1],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[8],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[11],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="7",Home=klubi[0],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d7},
                new Match(){Round="7",Home=klubi[1],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[4],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[6],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[8],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[10],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="8",Home=klubi[9],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[11],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[3],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[2],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[7],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[5],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d8 }
            };
            return games;
        }
        public ICollection<Match> GenerateFor16Teams(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.01, 2);
            var d2 = Math.Round(startData + 0.02, 2);
            var d3 = Math.Round(startData + 0.03, 2);
            var d4 = Math.Round(startData + 0.04, 2);
            var d5 = Math.Round(startData + 0.05, 2);
            var d6 = Math.Round(startData + 0.06, 2);
            var d7 = Math.Round(startData + 0.07, 2);
            var d8 = Math.Round(startData + 0.08, 2);
            var games = new List<Match>()
            {
                new Match(){Round="1",Home=klubi[0],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[2],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[10],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[8],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[4],Away=klubi[15],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[6],Away=klubi[13],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[12],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[14],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="2",Home=klubi[15],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[13],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[3],Away=klubi[12],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[1],Away=klubi[14],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[11],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[9],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[5],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[7],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="3",Home=klubi[0],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[2],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[4],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[6],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[8],Away=klubi[15],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[10],Away=klubi[13],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[14],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[12],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="4",Home=klubi[1],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[3],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[5],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[7],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[9],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[11],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[15],Away=klubi[12],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[13],Away=klubi[14],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="5",Home=klubi[0],Away=klubi[13],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[2],Away=klubi[15],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[12],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[14],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[4],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[6],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[10],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[8],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="6",Home=klubi[7],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[5],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[3],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[1],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[13],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[15],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[9],Away=klubi[14],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[11],Away=klubi[12],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="7",Home=klubi[0],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d7},
                new Match(){Round="7",Home=klubi[2],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[4],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[6],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[8],Away=klubi[9],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[10],Away=klubi[11],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[12],Away=klubi[13],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[14],Away=klubi[15],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="8",Home=klubi[9],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[11],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[3],Away=klubi[10],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[1],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[13],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[15],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[5],Away=klubi[12],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[7],Away=klubi[14],TournamentId=turnir.Id,Neytral=false,Data=d8 },
            };
            return games;
        }
        public ICollection<Match> GenerateFor9Teams(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.01, 2);
            var d2 = Math.Round(startData + 0.02, 2);
            var d3 = Math.Round(startData + 0.03, 2);
            var d4 = Math.Round(startData + 0.04, 2);
            var d5 = Math.Round(startData + 0.05, 2);
            var d6 = Math.Round(startData + 0.06, 2);
            var d7 = Math.Round(startData + 0.07, 2);
            var d8 = Math.Round(startData + 0.08, 2);
            var d9 = Math.Round(startData + 0.09, 2);
            var games = new List<Match>()
            {
                new Match(){Round="1",Home=klubi[1],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[2],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="1",Home=klubi[3],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d1},
                new Match(){Round="1",Home=klubi[4],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d1 },
                new Match(){Round="2",Home=klubi[6],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[7],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[8],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="2",Home=klubi[0],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d2 },
                new Match(){Round="3",Home=klubi[2],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[3],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[4],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="3",Home=klubi[5],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d3 },
                new Match(){Round="4",Home=klubi[7],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[8],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[0],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="4",Home=klubi[1],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d4 },
                new Match(){Round="5",Home=klubi[3],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[4],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[5],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="5",Home=klubi[6],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d5 },
                new Match(){Round="6",Home=klubi[8],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[0],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[1],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="6",Home=klubi[2],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d6 },
                new Match(){Round="7",Home=klubi[4],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[5],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[6],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="7",Home=klubi[7],Away=klubi[8],TournamentId=turnir.Id,Neytral=false,Data=d7 },
                new Match(){Round="8",Home=klubi[0],Away=klubi[7],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[1],Away=klubi[6],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[2],Away=klubi[5],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="8",Home=klubi[3],Away=klubi[4],TournamentId=turnir.Id,Neytral=false,Data=d8 },
                new Match(){Round="9",Home=klubi[5],Away=klubi[3],TournamentId=turnir.Id,Neytral=false,Data=d9 },
                new Match(){Round="9",Home=klubi[6],Away=klubi[2],TournamentId=turnir.Id,Neytral=false,Data=d9 },
                new Match(){Round="9",Home=klubi[7],Away=klubi[1],TournamentId=turnir.Id,Neytral=false,Data=d9 },
                new Match(){Round="9",Home=klubi[8],Away=klubi[0],TournamentId=turnir.Id,Neytral=false,Data=d9 }
            };
            return games;
        }
        public ICollection<Match> Qualification(Tournament turnir, List<Team> klubi, string round, double startData)
        {
            int t2 = klubi.Count / 2;
            var games = new List<Match>();
            {
                for (int i = 0; i < t2; i++)
                {
                    var match = new Match() { Round = round, Home = klubi[i], Away = klubi[i + t2], TournamentId = turnir.Id, Neytral = true, Data = startData };
                    games.Add(match);
                }
            };
            return games;
        }
        public ICollection<Match> QualificationDouble(Tournament turnir, List<Team> klubi, string round, double startData)
        {
            var d2 = startData + 0.1;
            int t2 = klubi.Count / 2;
            var games = new List<Match>();
            {
                for (int i = 0; i < t2; i++)
                {
                    var match = new Match() { Round = round, Home = klubi[i], Away = klubi[i + t2], TournamentId = turnir.Id, Neytral = false, Data = startData };
                    games.Add(match);
                }
                for (int i = 0; i < t2; i++)
                {
                    var match = new Match() { Round = round, Home = klubi[i + t2], Away = klubi[i], TournamentId = turnir.Id, Neytral = false, Data = d2 };
                    games.Add(match);
                }
            };
            return games;
        }
        public ICollection<Match> Quarters(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.06, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "1/4 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = true, Data = d1 },
            };
            return games;
        }
        public ICollection<Match> QuartersDouble(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.06, 2);
            var d2 = Math.Round(startData + 0.07, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "1/4 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/4 finals", Home = klubi[7], Away = klubi[6], TournamentId = turnir.Id, Neytral = false, Data = d2 },
                new Match() { Round = "1/4 finals", Home = klubi[5], Away = klubi[4], TournamentId = turnir.Id, Neytral = false, Data = d2 },
                new Match() { Round = "1/4 finals", Home = klubi[3], Away = klubi[2], TournamentId = turnir.Id, Neytral = false, Data = d2 },
                new Match() { Round = "1/4 finals", Home = klubi[1], Away = klubi[0], TournamentId = turnir.Id, Neytral = false, Data = d2 }
            };
            return games;
        }
        public ICollection<Match> Semi(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.07, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "1/2 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/2 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = false, Data = d1 },
            };
            return games;
        }
        public ICollection<Match> SemiDouble(Tournament turnir, List<Team> klubi, double startData)
        {
            var d1 = Math.Round(startData + 0.08, 2);
            var d2 = Math.Round(startData + 0.09, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "1/2 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/2 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = false, Data = d1 },
                new Match() { Round = "1/2 finals", Home = klubi[3], Away = klubi[2], TournamentId = turnir.Id, Neytral = false, Data = d2 },
                new Match() { Round = "1/2 finals", Home = klubi[1], Away = klubi[0], TournamentId = turnir.Id, Neytral = false, Data = d2 }
            };
            return games;
        }
        public ICollection<Match> Shedulle16(Tournament turnir, List<Team> klubi, double startData)
        {
            var d = Math.Round(startData + 0.04, 3);
            var games = new List<Match>()
            {
                new Match() { Round = "1/16 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[8], Away = klubi[9], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[10], Away = klubi[11], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[12], Away = klubi[13], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[14], Away = klubi[15], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[16], Away = klubi[17], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[18], Away = klubi[19], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[20], Away = klubi[21], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[22], Away = klubi[23], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[24], Away = klubi[25], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[26], Away = klubi[27], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[28], Away = klubi[29], TournamentId = turnir.Id, Neytral = true, Data = d },
                new Match() { Round = "1/16 finals", Home = klubi[30], Away = klubi[31], TournamentId = turnir.Id, Neytral = true, Data = d }
            };
            return games;
        }
        public ICollection<Match> Shedulle32(Tournament turnir, List<Team> klubi, double startData)
        {
            var data = Math.Round(startData + 0.02, 2);
            var games = new List<Match>()
            {
                new Match() { Round = "1/32 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[8], Away = klubi[9], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[10], Away = klubi[11], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[12], Away = klubi[13], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[14], Away = klubi[15], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[16], Away = klubi[17], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[18], Away = klubi[19], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[20], Away = klubi[21], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[22], Away = klubi[23], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[24], Away = klubi[25], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[26], Away = klubi[27], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[28], Away = klubi[29], TournamentId = turnir.Id, Neytral = true, Data = data },
                new Match() { Round = "1/32 finals", Home = klubi[30], Away = klubi[31], TournamentId = turnir.Id, Neytral = true, Data = data }
            };
            return games;
        }
        public ICollection<Match> Shedulle8(Tournament turnir, List<Team> klubi, double startData)
        {
            var d = Math.Round(startData + 0.05, 2);
            var games = new List<Match>()
            {
                new Match() {Round="1/8 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[8], Away = klubi[9], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[10], Away = klubi[11], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[12], Away = klubi[13], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[14], Away = klubi[15], TournamentId = turnir.Id, Neytral = true, Data = d}
            };
            return games;
        }
        public ICollection<Match> ShedulleEuro8(Tournament turnir, List<Team> klubi, double startData)
        {
            var d = Math.Round(startData + 0.05, 2);
            var games = new List<Match>()
            {
                new Match() {Round="1/8 finals", Home = klubi[0], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[2], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[4], Away = klubi[5], TournamentId = turnir.Id, Neytral = true, Data = d},
                new Match() {Round="1/8 finals", Home = klubi[6], Away = klubi[7], TournamentId = turnir.Id, Neytral = true, Data = d},
            };
            return games;
        }
        public List<Match> EuroGroupShedulle(Tournament turnir, List<Team> klubi, double startData , string Name)
        {
            double d1 = startData + 0.01;
            double d2 = startData + 0.02;
            double d3 = startData + 0.03;
            double d4 = startData + 0.04;
            double d5 = startData + 0.05;
            var games = new List<Match>()
            {
                new Match() {Group=Name, Round = "1", Home = klubi[0], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() {Group=Name, Round = "1", Home = klubi[2], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() {Group=Name, Round = "2", Home = klubi[4], Away = klubi[0], TournamentId = turnir.Id, Neytral = true, Data = d2 },
                new Match() {Group=Name, Round = "2", Home = klubi[3], Away = klubi[2], TournamentId = turnir.Id, Neytral = true, Data = d2 },
                new Match() {Group=Name, Round = "3", Home = klubi[1], Away = klubi[4], TournamentId = turnir.Id, Neytral = true, Data = d3 },
                new Match() {Group=Name, Round = "3", Home = klubi[0], Away = klubi[2], TournamentId = turnir.Id, Neytral = true, Data = d3 },
                new Match() {Group=Name, Round = "4", Home = klubi[4], Away = klubi[2], TournamentId = turnir.Id, Neytral = true, Data = d4 },
                new Match() {Group=Name, Round = "4", Home = klubi[1], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d4 },
                new Match() {Group=Name, Round = "5", Home = klubi[1], Away = klubi[0], TournamentId = turnir.Id, Neytral = true, Data = d5 },
                new Match() {Group=Name, Round = "5", Home = klubi[3], Away = klubi[4], TournamentId = turnir.Id, Neytral = true, Data = d5 }
            };
            return games;
        }
        public List<Match> GroupShedulle(Tournament turnir, List<Team> klubi, double startData, string Name)
        {
            double d1 = startData + 0.01;
            double d2 = startData + 0.02;
            double d3 = startData + 0.03;
            var games = new List<Match>()
            {
                new Match() {Group=Name, Round = "1", Home = klubi[0], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() {Group=Name, Round = "1", Home = klubi[2], Away = klubi[1], TournamentId = turnir.Id, Neytral = true, Data = d1 },
                new Match() {Group=Name, Round = "2", Home = klubi[1], Away = klubi[0], TournamentId = turnir.Id, Neytral = true, Data = d2 },
                new Match() {Group=Name, Round = "2", Home = klubi[3], Away = klubi[2], TournamentId = turnir.Id, Neytral = true, Data = d2 },
                new Match() {Group=Name, Round = "3", Home = klubi[0], Away = klubi[2], TournamentId = turnir.Id, Neytral = true, Data = d3 },
                new Match() {Group=Name, Round = "3", Home = klubi[1], Away = klubi[3], TournamentId = turnir.Id, Neytral = true, Data = d3 }
            };
            return games;
        }
    }
}
