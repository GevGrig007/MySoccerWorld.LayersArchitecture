using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using MySoccerWorld.Services;
using MySoccerWorld.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ILogger<TournamentsController> _logger;
        private readonly IDataManager db;
        private readonly ITournamentService _serv;
        public TournamentsController(ILogger<TournamentsController> logger, IDataManager context, ITournamentService service)
        {
            _logger = logger;
            db = context;
            _serv = service;
        }
        public IActionResult Index()
        {
            var leagues = db.Leagues.GetAll();
            return View(leagues);
        }
        public IActionResult OnlyRegional()
        {
            var leagues = db.Leagues.GetAll().Where(l => l.Type == "Regional").ToList();
            return View("Index", leagues);
        }
        public IActionResult OnlyEuroCups()
        {
            var leagues =  db.Leagues.GetAll().Where(l => l.Type == "EuroCup").ToList();
            return View("Index", leagues);
        }
        public IActionResult OnlyNational()
        {
            var leagues =  db.Leagues.GetAll().Where(l => l.Type == "National").ToList();
            return View("Index", leagues);
        }
        //Details
        //public IActionResult Details(int id)
        //{
        //    var matches = db.Matches.GetByTournament(id);
        //    var tournament = db.Tournaments.Details(id);
        //    if (!matches.Any())
        //    {
        //        var emptyTournamnet = new TournamentViewModel()
        //        {
        //            Tournament = tournament,
        //            Teams = tournament.Teams.ToList(),
        //            Matches = matches.ToList(),
        //            BestPlayer = db.BestPlayers.GetByTournament(id).ToList()
        //        };
        //        return View(emptyTournamnet);
        //    }
        //    else if (tournament.TournamentType == TournamentType.Regular){
        //        var standings = _serv.CalculatingTable(matches, tournament.Teams);
        //        var tournamentView = new TournamentViewModel()
        //        {
        //            Tournament = tournament,
        //            Teams = tournament.Teams.ToList(),
        //            Matches = matches.ToList(),
        //            Goals = db.PlayerTeams.GoalScorers(id),
        //            Asists = db.PlayerTeams.Asisters(id),
        //            BestPlayer = db.BestPlayers.GetByTournament(id).ToList(),
        //            TournamentStandings = standings.OrderByDescending(c => c.Points)
        //                                           .ThenByDescending(c => c.GoalDifference)
        //                                           .ThenByDescending(c => c.GoalsFor)
        //        };
        //        return View(tournamentView);
        //    }
        //    else if (tournament.TournamentType == TournamentType.EuroCup)
        //    {

        //    }
        //}
        public async Task<IActionResult> RegionalDetails(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var matches =  db.Matches.GetByTournament(id);
            if (matches.Count() > 0)
            {
                var standings = _serv.CalculatingTable(matches, tournament.Teams);
                var tournamentView = new TournamentViewModel()
                {
                    Tournament = tournament,
                    Teams = tournament.Teams.ToList(),
                    Matches = matches.ToList(),
                    Goals = db.PlayerTeams.GoalScorers(id),
                    Asists = db.PlayerTeams.Asisters(id),
                    BestPlayer = await db.BestPlayers.GetByTournamentAsync(id),
                    TournamentStandings = standings.OrderByDescending(c => c.Points)
                                                   .ThenByDescending(c => c.GoalDifference)
                                                   .ThenByDescending(c => c.GoalsFor)
                };
                return View(tournamentView);
            }
            var emptyTournamnet = new TournamentViewModel()
            {
                Tournament = tournament,
                Teams = tournament.Teams.ToList(),
                Matches = matches.ToList(),
                BestPlayer = await db.BestPlayers.GetByTournamentAsync(id)
            };
            return View(emptyTournamnet);
        }
        public async Task<IActionResult> EuroCupDetails(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var matches = db.Matches.GetByTournament(id);
            if (matches.Any())
            {
                var tournamentView = new EuroCupViewModel()
                {
                    Tournament = tournament,
                    Teams = tournament.Teams.ToList(),
                    Matches = matches.ToList(),
                    Goals = db.PlayerTeams.GoalScorers(id),
                    Asists = db.PlayerTeams.Asisters(id),
                    BestPlayer = await db.BestPlayers.GetByTournamentAsync(id),
                    Groups = _serv.Group8(tournament)
                };
                return View(tournamentView);
            };
            var emptyTournamnet = new EuroCupViewModel()
            {
                Tournament = tournament,
                Teams = tournament.Teams.ToList(),
                Matches = matches.ToList(),
                BestPlayer = await db.BestPlayers.GetByTournamentAsync(id) 
            };
            return View(emptyTournamnet);
        }
        public async Task<IActionResult> EuroCupKnockOut(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var matches = db.Matches.GetByTournament(id);
            var tournamentView = new KnockOutViewModel()
            {
                Tournament = tournament,
                Teams = tournament.Teams.ToList(),
                Matches = matches.ToList(),
                Goals = db.PlayerTeams.GoalScorers(id),
                Asists = db.PlayerTeams.Asisters(id),
                BestPlayer = await db.BestPlayers.GetByTournamentAsync(id) 
            };
            return View(tournamentView);
        }
        public async Task<IActionResult> NationalDetails(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var matches = db.Matches.GetByTournament(id);
            if (matches.Any())
            {
                var tournamentView = new EuroCupViewModel()
                {
                    Tournament = tournament,
                    Teams = tournament.Teams.ToList(),
                    Matches = matches.ToList(),
                    Goals = db.PlayerTeams.GoalScorers(id),
                    Asists = db.PlayerTeams.Asisters(id),
                    BestPlayer = await db.BestPlayers.GetByTournamentAsync(id),
                    Groups = _serv.Group2(tournament)
                };
                return View(tournamentView);
            };
            var emptyTournamnet = new EuroCupViewModel()
            {
                Tournament = tournament,
                Teams = tournament.Teams.ToList(),
                Matches = matches.ToList(),
                BestPlayer = await db.BestPlayers.GetByTournamentAsync(id)
            };
            return View(emptyTournamnet);
        }
        public async Task<IActionResult> NationalEuro(int id)
        {
            var tournament = db.Tournaments.Details(id);
            var matches = db.Matches.GetByTournament(id);
            if (matches.Any())
            {
                var tournamentView = new EuroCupViewModel()
                {
                    Tournament = tournament,
                    Teams = tournament.Teams.ToList(),
                    Matches = matches.ToList(),
                    Goals = db.PlayerTeams.GoalScorers(id),
                    Asists = db.PlayerTeams.Asisters(id),
                    BestPlayer = await db.BestPlayers.GetByTournamentAsync(id),
                    Groups = _serv.EuroGroup(tournament)
                };
                return View(tournamentView);
            };
            var emptyTournamnet = new EuroCupViewModel()
            {
                Tournament = tournament,
                Teams = tournament.Teams.ToList(),
                Matches = matches.ToList(),
                BestPlayer = await db.BestPlayers.GetByTournamentAsync(id)
            };
            return View(emptyTournamnet);
        }
        public IActionResult Qualification(int id)
        {
            var view = new QualificationViewModel()
            {
                Tournament = db.Tournaments.Details(id),
                Matches = db.Matches.GetByTournament(id).ToList()
            };
            return View(view);
        }
        // CRUD Tournaments 
        public IActionResult TournamentManage(int id)
        {
            var tournaments = db.Tournaments.GetByLeague(id);
            ViewBag.Leagues = new SelectList(db.Leagues.GetAll(), "Id", "Name");
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll().OrderByDescending(s => s.Data), "Id", "Data");
            return View(tournaments);
        }
        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            ViewBag.Leagues = new SelectList(db.Leagues.GetAll(), "Id", "Name", tournament.LeagueId);
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll(), "Id", "Data", tournament.SeasonId);
            db.Tournaments.Update(tournament);
            db.Save();
            return RedirectToAction("TournamentManage", "Tournaments", new { id = tournament.LeagueId });
        }
        public IActionResult Edit(int id)
        {
            var tournament =  db.Tournaments.Get(id);
            ViewBag.Leagues = new SelectList(db.Leagues.GetAll(), "Id", "Name");
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll(), "Id", "Data");
            return PartialView(tournament);
        }
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            ViewBag.Leagues = new SelectList(db.Leagues.GetAll(), "Id", "Name", tournament.LeagueId);
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll(), "Id", "Data", tournament.SeasonId);
            db.Tournaments.Update(tournament);
            db.Save();
            return RedirectToAction("TournamentManage", "Tournaments", new { id = tournament.LeagueId });
        }
        [HttpPost]
        public IActionResult EditBP(int id, BestPlayerFormation bp)
        {
            var tournament = db.Tournaments.Get(id);
            tournament.BestPlayerFormation = bp;
            db.Tournaments.Update(tournament);
            db.Save();
            var link = "";
            if (tournament.TournamentType == TournamentType.Regular)
            {
                link = "RegionalDetails";
            }
            else if (tournament.TournamentType == TournamentType.EuroCup)
            {
                link = "EuroCupDetails";
            }
            else if (tournament.TournamentType == TournamentType.EuroCupKnockOut)
            {
                link = "EuroCupKnockOut";
            }
            else if (tournament.TournamentType == TournamentType.National8)
            {
                link = "NationalDetails";
            }
            else if (tournament.TournamentType == TournamentType.NationalEuro)
            {
                link = "NationalEuro";
            }
            else if (tournament.TournamentType == TournamentType.Qualification)
            {
                link = "Qualification";
            }
            return RedirectToAction(link, "Tournaments", new { id = tournament.Id });
        }
        public IActionResult Delete(int id)
        {
            var tournament = db.Tournaments.Get(id);
            return PartialView(tournament);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Tournament tournament)
        {
            db.Tournaments.Delete(tournament.Id);
            db.Save();
            return RedirectToAction("TournamentManage", "Tournaments", new { id = tournament.LeagueId });
        }
        // Matches
        public IActionResult Matches(int id)
        {
            var tournament =  db.Tournaments.Details(id);
            ViewBag.Matches = db.Matches.GetByTournament(id).OrderBy(m => m.Round);
            return View(tournament);
        }
        // GoalScorers
        public IActionResult GoalScorers(int id)
        {
            var view = new GoalScorersViewModel()
            {
                PlayerTeams = db.Goals.GetGoalsByTournament(id),
                Tournament = db.Tournaments.Get(id),
                TournamentAwards = db.Awards.GetByTournament(id)
            };
            return View(view);
        }
        public IActionResult CreateAwards(int id)
        {
            Tournament tournament = db.Tournaments.Get(id);
            ViewBag.Tournament = tournament;
            ViewBag.Players = new SelectList(db.Players.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Coaches = new SelectList(db.Coaches.GetAll().OrderBy(p => p.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateAwards(int TournamentId, int? PlayerTeamId, int? CoachTeamId, AwardType AwardsName)
        {
            var tournamentaward = new TournamentAward();
            if (PlayerTeamId != null)
            {
                tournamentaward.PlayerTeamId = db.Awards.GetPlayerAward(PlayerTeamId).Id;
                tournamentaward.TournamentId = TournamentId;
                tournamentaward.AwardName = AwardsName;
                db.Awards.Update(tournamentaward);
                db.Save();
            }
            if (CoachTeamId != null)
            {
                var coach = db.Coaches.Get(CoachTeamId);
                tournamentaward.CoachTeamId = coach.Id;
                tournamentaward.TournamentId = TournamentId;
                tournamentaward.AwardName = AwardsName;
                db.Awards.Update(tournamentaward);
                db.Save();
            }
            return RedirectToAction("GoalScorers", new { id = TournamentId });
        }
    }
}
