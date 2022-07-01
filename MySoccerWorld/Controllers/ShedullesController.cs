using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class ShedullesController : Controller
    {
        private readonly ILogger<ShedullesController> _logger;
        private readonly IDataManager db;
        private IShedulleService _serv;
        public ShedullesController(ILogger<ShedullesController> logger, IDataManager context, IShedulleService service)
        {
            _logger = logger;
            db = context;
            _serv = service;
        }
        public async Task<IActionResult> Index(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var teams = tournament.Teams.ToList();
            ViewBag.Teams = new SelectList(teams, "Id", "Name");
            ViewBag.BestPlayers = await db.BestPlayers.GetByTournamentAsync(id);
            return View(tournament);
        }
        // Add Teams
        [HttpGet]
        public IActionResult AddTeams(int id)
        {
            Tournament tournament = db.Tournaments.Details(id);
            if (tournament == null)
            {
                return NotFound();
            }
            ViewBag.Clubs = db.Clubs.GetAll().Where(c => c.Country.Region == tournament.League.Region).ToList();
            ViewBag.EuroClubs =  db.Clubs.GetAll().ToList();
            ViewBag.Nationals = db.Nationals.GetAll().OrderBy(n => n.Region).ToList();
            return View(tournament);
        }
        [HttpPost]
        public IActionResult AddTeams(Tournament tournament, int[] selectedClubs)
        {
            Tournament newTournament = db.Tournaments.Get(tournament.Id);
            newTournament.Name = tournament.Name;
            newTournament.Teams.Clear();
            if (selectedClubs != null)
            {
                foreach (var c in db.Teams.GetAll().Where(c => selectedClubs.Contains(c.Id)))
                {
                    newTournament.Teams.Add(c);
                }
            }
            db.Tournaments.Update(newTournament);
            db.Save();
            return RedirectToAction("Index", new { id = newTournament.Id });
        }
        // Sheduelles

        [HttpPost]
        public IActionResult ShedulleFor9(int id, int[] clubs, double data)
        {
            Tournament tournament =  db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.GenerateFor9Teams(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleFor12(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.GenerateFor12Teams(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleFor16(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.GenerateFor16Teams(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleGroup(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            if (teams.Count == 32)
            {
                var groupAteams = new List<Team> { teams[0], teams[1], teams[2], teams[3] };
                var groupBteams = new List<Team> { teams[4], teams[5], teams[6], teams[7] };
                var groupCteams = new List<Team> { teams[8], teams[9], teams[10], teams[11] };
                var groupDteams = new List<Team> { teams[12], teams[13], teams[14], teams[15] };
                var groupEteams = new List<Team> { teams[16], teams[17], teams[18], teams[19] };
                var groupFteams = new List<Team> { teams[20], teams[21], teams[22], teams[23] };
                var groupGteams = new List<Team> { teams[24], teams[25], teams[26], teams[27] };
                var groupHteams = new List<Team> { teams[28], teams[29], teams[30], teams[31] };
                var groupA = new TournamentGroup { Name = "A" };
                var groupAm = _serv.GroupShedulle(tournament, groupAteams, data,groupA.Name);
                db.Matches.AddRange(groupAm);
                var groupB = new TournamentGroup { Name = "B" };
                var groupBm = _serv.GroupShedulle(tournament, groupBteams, data,groupB.Name);
                db.Matches.AddRange(groupBm);
                var groupC = new TournamentGroup { Name = "C" };
                var groupCm = _serv.GroupShedulle(tournament, groupCteams, data, groupC.Name);
                db.Matches.AddRange(groupCm);
                var groupD = new TournamentGroup { Name = "D" };
                var groupDm = _serv.GroupShedulle(tournament, groupDteams, data,groupD.Name);
                db.Matches.AddRange(groupDm);
                var groupE = new TournamentGroup { Name = "E" };
                var groupEm = _serv.GroupShedulle(tournament, groupEteams, data, groupE.Name);
                db.Matches.AddRange(groupEm);
                var groupF = new TournamentGroup { Name = "F" };
                var groupFm = _serv.GroupShedulle(tournament, groupFteams, data, groupF.Name);
                db.Matches.AddRange(groupFm);
                var groupG = new TournamentGroup { Name = "G" };
                var groupGm = _serv.GroupShedulle(tournament, groupGteams, data,groupG.Name);
                db.Matches.AddRange(groupGm);
                var groupH = new TournamentGroup { Name = "H" };
                var groupHm = _serv.GroupShedulle(tournament, groupHteams, data, groupH.Name);
                db.Matches.AddRange(groupHm);
                db.Save();
            }
            else if (teams.Count == 20)
            {
                var groupAteams = new List<Team> { teams[0], teams[1], teams[2], teams[3], teams[4] };
                var groupBteams = new List<Team> { teams[5], teams[6], teams[7], teams[8], teams[9] };
                var groupCteams = new List<Team> { teams[10], teams[11], teams[12], teams[13], teams[14] };
                var groupDteams = new List<Team> { teams[15], teams[16], teams[17], teams[18], teams[19] };
                var groupA = new TournamentGroup { Name = "A" };
                var groupAm = _serv.EuroGroupShedulle(tournament, groupAteams, data, groupA.Name);
                db.Matches.AddRange(groupAm);
                var groupB = new TournamentGroup { Name = "B" };
                var groupBm = _serv.EuroGroupShedulle(tournament, groupBteams, data, groupB.Name);
                db.Matches.AddRange(groupBm);
                var groupC = new TournamentGroup { Name = "C" };
                var groupCm = _serv.EuroGroupShedulle(tournament, groupCteams, data, groupC.Name);
                db.Matches.AddRange(groupCm);
                var groupD = new TournamentGroup { Name = "D" };
                var groupDm = _serv.EuroGroupShedulle(tournament, groupDteams, data, groupD.Name);
                db.Matches.AddRange(groupDm);
            }
            else if (teams.Count == 16)
            {
                var groupAteams = new List<Team> { teams[0], teams[1], teams[2], teams[3] };
                var groupBteams = new List<Team> { teams[4], teams[5], teams[6], teams[7] };
                var groupCteams = new List<Team> { teams[8], teams[9], teams[10], teams[11] };
                var groupDteams = new List<Team> { teams[12], teams[13], teams[14], teams[15] };
                var groupA = new TournamentGroup { Name = "A" };
                var groupAm = _serv.GroupShedulle(tournament, groupAteams, data, groupA.Name);
                db.Matches.AddRange(groupAm);
                var groupB = new TournamentGroup { Name = "B" };
                var groupBm = _serv.GroupShedulle(tournament, groupBteams, data, groupB.Name);
                db.Matches.AddRange(groupBm);
                var groupC = new TournamentGroup { Name = "C" };
                var groupCm = _serv.GroupShedulle(tournament, groupCteams, data, groupC.Name);
                db.Matches.AddRange(groupCm);
                var groupD = new TournamentGroup { Name = "D" };
                var groupDm = _serv.GroupShedulle(tournament, groupDteams, data, groupD.Name);
                db.Matches.AddRange(groupDm);
            }
            else if (teams.Count == 8)
            {
                var groupAteams = new List<Team> { teams[0], teams[1], teams[2], teams[3] };
                var groupBteams = new List<Team> { teams[4], teams[5], teams[6], teams[7] };
                var groupA = new TournamentGroup { Name = "A" };
                var groupAm = _serv.GroupShedulle(tournament, groupAteams, data, groupA.Name);
                db.Matches.AddRange(groupAm);
                var groupB = new TournamentGroup { Name = "B" };
                var groupBm = _serv.GroupShedulle(tournament, groupBteams, data, groupB.Name);
                db.Matches.AddRange(groupBm);
            }
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleKnockOut32(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.Shedulle32(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleKnockOut16(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.Shedulle16(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleKnockOut8(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.Shedulle8(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedullEuro8(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.ShedulleEuro8(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleQuarter(int id, int[] clubs, double data , string matchcount)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            if (matchcount == "1")
            {
                var fixtures = _serv.Quarters(tournament, teams, data);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            else
            {
                var fixtures = _serv.QuartersDouble(tournament, teams, data);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleSemi(int id, int[] clubs, double data , string matchcount)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            if (matchcount == "1")
            {
                var fixtures = _serv.Semi(tournament, teams, data);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            else
            {
                var fixtures = _serv.SemiDouble(tournament, teams, data);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        [HttpPost]
        public IActionResult ShedulleFinal(int id, int[] clubs, double data)
        {
            Tournament tournament = db.Tournaments.Get(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            var fixtures = _serv.Final(tournament, teams, data);
            db.Matches.AddRange(fixtures);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = tournament.Id });
        }
        public IActionResult ShedulleQualification(int id, int teamscount)
        {
            var tournament = db.Tournaments.Details(id);
            ViewBag.Teams = new SelectList(tournament.Teams, "Id", "Name");
            ViewBag.TeamsCount = teamscount;
            return View(tournament);
        }
        [HttpPost]
        public IActionResult ShedulleQualification(int id, string round, string matchcount, int[] clubs, double data ,bool neytral )
        {
            var tournament = db.Tournaments.Details(id);
            var teams = new List<Team>();
            for (var i = 0; i < clubs.Length; i++)
            {
                var team = db.Teams.Get(clubs[i]);
                teams.Add(team);
            };
            if (matchcount == "1")
            {
                var fixtures = _serv.Qualification(tournament, teams, round, data, neytral);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            else
            {
                var fixtures = _serv.QualificationDouble(tournament, teams, round, data, neytral);
                db.Matches.AddRange(fixtures);
                db.Save();
            }
            return RedirectToAction("Details", "Tournaments" , new {id= tournament.Id});
        }
    }
}
